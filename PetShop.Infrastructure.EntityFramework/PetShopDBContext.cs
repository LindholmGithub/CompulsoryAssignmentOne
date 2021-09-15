using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.EntityFramework.Entities;

namespace PetShop.Infrastructure.EntityFramework
{
    public class PetShopDBContext : DbContext
    {
        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 1, Name = "Piphans", Price = 22});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 2, Name = "Rollo, fra Rollo og King", Price = 222});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 3, Name = "King", Price = 2222});

        }

        public DbSet<InsuranceEntity> Insurances { get; set; }
        
    }
}