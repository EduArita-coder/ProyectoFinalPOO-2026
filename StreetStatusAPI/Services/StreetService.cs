using Microsoft.EntityFrameworkCore;
using StreetStatusAPI.Database;
using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Services
{
    public class StreetService : IStreetService
    {
        private readonly StreetDbContext _context;

        public StreetService(StreetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Street>> GetAllAsync()
        {
            return await _context.Streets.Include(s => s.Location).Include(s => s.User).ToListAsync();
        }

        public async Task<Street> GetByIdAsync(int id)
        {
            return await _context.Streets.Include(s => s.Location).Include(s => s.User).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Street> CreateAsync(Street street)
        {
            street.CreatedDate = DateTime.UtcNow;
            _context.Streets.Add(street);
            await _context.SaveChangesAsync();
            return street;
        }
    }
}