using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IPetTypeRepositories
    {
        List<PetType> GetAllPetTypes();
        PetType ReadById(int id);
        PetType Create(PetType petType);
        PetType Delete(int petTypeId);
        PetType Update(PetType petType);
    }
}