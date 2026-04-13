using Microsoft.EntityFrameworkCore;
using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Database
{
    public class StreetDbContext : DbContext
    {
        public StreetDbContext(DbContextOptions<StreetDbContext> options) : base(options) { }

        public DbSet<Street> Streets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Locations
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Configuración de la tabla Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Configuración de la tabla Streets
            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .HasConversion<int>();

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relación con Location
                entity.HasOne(s => s.Location)
                    .WithMany(l => l.Streets)
                    .HasForeignKey(s => s.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con User
                entity.HasOne(s => s.User)
                    .WithMany(u => u.ReportedStreets)
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}