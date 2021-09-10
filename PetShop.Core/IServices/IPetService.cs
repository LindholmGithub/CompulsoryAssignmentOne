using System;
using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        List<Pet> GetPetsByType(string searchedWords);
        Pet Create(Pet pet);
        string Delete(int petId);
        void UpdatePetName(int idToUpdate, string newPetName);
        void UpdatePetType(int idToUpdate, string newPetType);
        void UpdatePetBirthDate(int idToUpdate, DateTime newPetBirthDate);
        void UpdatePetSoldDate(int idToUpdate, DateTime newPetSoldDate);
        void UpdatePetColor(int idToUpdate, string newPetColor);
        void UpdatePetPrice(int idToUpdate, double newPetPrice);
        void Update(Pet pet);
    }
}