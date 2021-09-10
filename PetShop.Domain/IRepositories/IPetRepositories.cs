using System;
using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IPetRepositories
    {
        List<Pet> GetAllPets();
        Pet Create(Pet pet);
        string Delete(int petId);
        Pet Update(Pet pet);
    }
}