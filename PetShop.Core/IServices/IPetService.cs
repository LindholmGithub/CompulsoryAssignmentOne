using System;
using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets(Filter.Filter filter);
        List<Pet> GetPetsByType(string searchedWords);
        Pet Create(Pet pet);
        Pet Delete(int petId);
        Pet Update(Pet pet);
        int TotalCount();
    }
}