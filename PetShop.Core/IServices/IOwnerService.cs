using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        Owner Create(Owner owner);
        Owner Delete(int ownerId);
        Owner Update(Owner owner);
    }
}