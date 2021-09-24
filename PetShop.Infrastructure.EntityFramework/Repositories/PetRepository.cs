using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.Infrastructure.EntityFramework.Entities;

namespace PetShop.Infrastructure.EntityFramework.Repositories
{
    public class PetRepository : IPetRepositories
    {
        private readonly PetShopDBContext _context;

        public PetRepository(PetShopDBContext context)
        {
            _context = context;
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets
                .Include(p => p.PetType)
                .Include(p => p.Insurance)
                .Select(pet => new Pet
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    BirthDate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Color = pet.Color,
                    Price = pet.Price,
                    Type = new PetType
                    {
                        Id = pet.PetType.Id,
                        Name = pet.PetType.Name
                    },
                    Insurance = new Insurance
                    {
                        Id = pet.Insurance.Id,
                        Name = pet.Insurance.Name,
                        Price = pet.Insurance.Price
                    }
                })
                .Take(50)
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Pet ReadById(int id)
        {
            return _context.Pets
                .Select(p => new Pet
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    SoldDate = p.SoldDate,
                    Color = p.Color,
                    Price = p.Price
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public Pet Create(Pet pet)
        {
            var entity = _context.Add(new PetEntity()
            {
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
                PetTypeId = pet.Type.Id,
                InsuranceId = pet.Insurance.Id,

            }).Entity;
            _context.SaveChanges();
            return new Pet()
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }

        public Pet Delete(int petId)
        {
            var entity = _context.Pets.Remove(new PetEntity {Id = petId}).Entity;
            _context.SaveChanges();
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }

        public Pet Update(Pet pet)
        {
            var petEntity = new PetEntity()
            {
                Id = pet.Id,
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
            var entity = _context.Update(petEntity).Entity;
            _context.SaveChanges();
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }
    }
}