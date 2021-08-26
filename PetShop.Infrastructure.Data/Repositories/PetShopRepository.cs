using System;
using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetShopRepository : IPetRepositories, IPetTypeRepositories
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _petId = 1;
        private static List<PetType> _petTypeTable = new List<PetType>();
        
        public List<Pet> GetAllPets()
        {
            return _petTable;
        }

        public Pet Create(Pet pet)
        {
            pet.Id = _petId++;
            _petTable.Add(pet);
            return pet;
        }
    }
}