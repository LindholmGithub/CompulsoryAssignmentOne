using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<Owner> _ownerTable = new List<Owner>();
        private static int _ownerId = 1;
        
        public OwnerRepository()
        {
            Owner owner1 = new Owner()
            {
                Id = 1,
                Name = "Bob"
            };
            Owner owner2 = new Owner()
            {
                Id = 2,
                Name = "Cruella"
            };
            Owner owner3 = new Owner()
            {
                Id = 3,
                Name = "Rollo, fra Rollo og King"
            };
            Create(owner1);
            Create(owner2);
            Create(owner3);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerTable;
        }

        public Owner Create(Owner owner)
        {
            owner.Id = _ownerId++;
            _ownerTable.Add(owner);
            return owner;
        }

        public Owner Delete(int ownerId)
        {
            _ownerTable = GetAllOwners();
            Owner ownerToReturn = new Owner();
            foreach (var owner in _ownerTable.ToList())
            {
                if (ownerId == owner.Id)
                {
                    _ownerTable.Remove(owner);
                    ownerToReturn = owner;
                }
            }
            return ownerToReturn;
        }

        public Owner Update(Owner owner)
        {
            var ownerToUpdate = _ownerTable.FirstOrDefault(o => o.Id == owner.Id);
            if (ownerToUpdate != null)
            {
                ownerToUpdate.Name = owner.Name;
            }
            return ownerToUpdate;
        }
    }
}