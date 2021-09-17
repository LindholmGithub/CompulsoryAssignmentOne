using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.Infrastructure.EntityFramework.Entities;

namespace PetShop.Infrastructure.EntityFramework.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDBContext _context;

        public InsuranceRepository(PetShopDBContext context)
        {
            _context = context;
            
        }

        public Insurance GetById(int id)
        {
            //Converter til et Insurance objekt fra en Insurance entitet.
            
            return _context.Insurances
                .Select(ie => new Insurance
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(i => i.Id == id);
        }

        public Insurance Create(Insurance insurance)
        {
            var entity = _context.Add(new InsuranceEntity()
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _context.SaveChanges();
            return new Insurance()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public List<Insurance> GetAll()
        {
            //Min egen metode
            
            //List<Insurance> insurances = new List<Insurance>();
            //foreach (var entity in _context.Insurances.ToList())
            //{
            //    insurances.Add(new Insurance()
            //    {
            //        Id = entity.Id,
            //        Name = entity.Name,
            //        Price = entity.Price
            //    });
            //}
            //return insurances;
            
            //Lars' Metode
            return _context.Insurances.Select(insurance => new Insurance
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            })
                .Take(50)
                .OrderBy(i => i.Name)
                .ToList();
        }

        public Insurance Delete(int id)
        {
            //Min egen metode
            
            //Insurance insurance = GetById(id);
            //_context.Remove(insurance);
            //return insurance;

            //Lars' metode
            var entity = _context.Remove(new InsuranceEntity {Id = id}).Entity;
            _context.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public Insurance Update(Insurance insurance)
        {
            var insuranceEntity = new InsuranceEntity
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            var entity = _context.Update(insuranceEntity).Entity;
            _context.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}