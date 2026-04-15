using Microsoft.EntityFrameworkCore;
using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Database
{
    public class StreetDbContext : DbContext
    {
        public StreetDbContext(DbContextOptions<StreetDbContext> options) : base(options) { }

        public DbSet<StreetEntity> Streets { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
    
}