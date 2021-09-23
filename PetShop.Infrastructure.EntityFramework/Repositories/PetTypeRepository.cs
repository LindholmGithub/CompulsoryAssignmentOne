using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.Infrastructure.EntityFramework.Entities;

namespace PetShop.Infrastructure.EntityFramework.Repositories
{
    public class PetTypeRepository : IPetTypeRepositories
    {
        private readonly PetShopDBContext _context;

        public PetTypeRepository(PetShopDBContext context)
        {
            _context = context;
        }

        public List<PetType> GetAllPetTypes()
        {
            return _context.PetTypes.Select(petType => new PetType()
                {
                    Id = petType.Id,
                    Name = petType.Name,
                })
                .Take(50)
                .OrderBy(pt => pt.Name)
                .ToList();
        }

        public PetType ReadById(int id)
        {
            return _context.PetTypes
                .Select(pt => new PetType
                {
                    Id = pt.Id,
                    Name = pt.Name
                })
                .FirstOrDefault(pt => pt.Id == id);
        }

        public PetType Create(PetType petType)
        {
            var entity = _context.Add(new PetTypeEntity()
            {
                Name = petType.Name
            }).Entity;
            _context.SaveChanges();
            return new PetType()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public PetType Delete(int petTypeId)
        {
            var entity = _context.PetTypes.Remove(new PetTypeEntity{Id = petTypeId}).Entity;
            _context.SaveChanges();
            return new PetType()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public PetType Update(PetType petType)
        {
            var petEntity = new PetTypeEntity()
            {
                Id = petType.Id,
                Name = petType.Name,
            };
            var entity = _context.Update(petEntity).Entity;
            _context.SaveChanges();
            return new PetType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}