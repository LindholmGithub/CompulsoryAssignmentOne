using System;
using System.Collections.Generic;
using PetShop.Core.Filter;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IPetRepositories
    {
        List<Pet> GetAllPets(Filter filter);
        Pet ReadById(int id);
        Pet Create(Pet pet);
        Pet Delete(int petId);
        Pet Update(Pet pet);
        int TotalCount();
    }
}