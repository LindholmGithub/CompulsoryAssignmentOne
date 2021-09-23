using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepositories
    {
        public List<PetType> GetAllPetTypes()
        {
            throw new System.NotImplementedException();
        }

        public PetType ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetType Create(PetType petType)
        {
            throw new System.NotImplementedException();
        }

        public PetType Delete(int petTypeId)
        {
            throw new System.NotImplementedException();
        }

        public PetType Update(PetType petType)
        {
            throw new System.NotImplementedException();
        }
    }
}