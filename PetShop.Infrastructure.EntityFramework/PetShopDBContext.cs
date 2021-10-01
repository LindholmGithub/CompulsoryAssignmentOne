using System;
using System.Collections.Generic;
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

            var random = new Random();
            var insNames = new List<string> {"AlfonsInsurance", "PiphansInsurance", "SørenInsurance"};
            var petNames = new List<string> {"Johnny", "Leo", "Tim"};
            for (var i = 1; i < 100; i++)
            {
                var insuranceName = $"{insNames[random.Next(0, 3)]} {i}";
                modelBuilder.Entity<InsuranceEntity>()
                    .HasData(new InsuranceEntity
                    {
                       Id = i,
                       Name = insuranceName
                    });
            }
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity {Id = 1, Name = "Dog"});
            for (var i = 1; i < 1000; i++)
            {
                var petName = $"{petNames[random.Next(0, 3)]} {i}";
                modelBuilder.Entity<PetEntity>().HasData(new PetEntity
                {
                    Id = i,
                    Name = petName,
                    PetTypeId = 1,
                    BirthDate = DateTime.Today,
                    SoldDate = DateTime.Now,
                    Color = "Brown",
                    Price = 5000,
                    InsuranceId = random.Next(1,100)
                });
            }
            

        }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        
        
    }
}