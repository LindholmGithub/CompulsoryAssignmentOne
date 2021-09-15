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
    }
}