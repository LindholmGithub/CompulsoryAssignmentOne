using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();
        Owner Create(Owner owner);
        Owner Delete(int ownerId);
        Owner Update(Owner owner);
    }
}