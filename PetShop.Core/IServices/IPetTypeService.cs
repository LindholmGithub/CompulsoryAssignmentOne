using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetAllPetTypes();
        PetType GetById(int id);
        PetType Create(PetType petType);
        PetType Delete(int petTypeId);
        PetType Update(PetType petType);
    }
}