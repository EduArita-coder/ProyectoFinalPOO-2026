using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Services
{
    public interface IStreetService
    {
        Task<IEnumerable<Street>> GetAllAsync();
        Task<Street> GetByIdAsync(int id);
        Task<Street> CreateAsync(Street street);
    }
}
