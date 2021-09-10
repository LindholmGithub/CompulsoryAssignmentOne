using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        public IOwnerRepository _repo;

        public OwnerService(IOwnerRepository repo)
        {
            _repo = repo;
        }

        public List<Owner> GetAllOwners()
        {
            return _repo.GetAllOwners();
        }

        public Owner Create(Owner owner)
        {
            return _repo.Create(owner);
        }

        public Owner Delete(int ownerId)
        {
            return _repo.Delete(ownerId);
        }

        public Owner Update(Owner owner)
        {
            return _repo.Update(owner);
        }
    }
}