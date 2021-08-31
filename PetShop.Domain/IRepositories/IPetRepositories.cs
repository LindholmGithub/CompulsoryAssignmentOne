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
        void UpdateName(int idToUpdate, string newPetName);
        void UpdatePetType(int idToUpdate, string newPetType);
        void UpdatePetBirthDate(int idToUpdate, DateTime newPetBirthDate);
        void UpdatePetSoldDate(int idToUpdate, DateTime newPetSoldDate);
        void UpdatePetColor(int idToUpdate, string newPetColor);
        void UpdatePetPrice(int idToUpdate, double newPetPrice);
    }
}