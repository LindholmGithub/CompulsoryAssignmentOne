using System;
using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.EntityFramework.Entities;

namespace PetShop.Infrastructure.EntityFramework
{
    public class PetShopDBContext : DbContext
    {
        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A Pet can have one PetType and a PetType can have many pets
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.PetType)
                .WithMany(pt => pt.Pets)
                .HasForeignKey(p => new {p.PetTypeId});
            
            //A Pet can have one Insurance and an Insurance can have many pets
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.Insurance)
                .WithMany(i => i.Pets)
                .HasForeignKey(p => new {p.InsuranceId});

            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 1, Name = "Piphans", Price = 22});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 2, Name = "Rollo, fra Rollo og King", Price = 222});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 3, Name = "King", Price = 2222});
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 1, Name = "Dog"});
            modelBuilder.Entity<PetEntity>().HasData(new PetEntity
            {
                Id = 1,
                Name = "Bobby",
                PetTypeId = 1,
                BirthDate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Brown",
                Price = 5000,
                InsuranceId = 2
            });

        }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        
        
    }
}