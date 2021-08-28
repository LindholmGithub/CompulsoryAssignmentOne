using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetShopRepository : IPetRepositories, IPetTypeRepositories
    {
        private static List<Pet> _petTable = new List<Pet>();
        private string deletedPetName;

        private static int _petId = 3;

        private static List<PetType> _petTypeTable = new List<PetType>();

        public PetShopRepository()
        {
            PetType dog = new PetType
            {
                Name = "Dog",
                Id = 1
            };
            PetType cat = new PetType
            {
                Name = "Cat",
                Id = 2
            };
            Pet pet1 = new Pet()
            {
                Id = 1,
                Name = "John",
                Type = dog,
                BirthDate = new DateTime(1979, 07, 28),
                SoldDate = new DateTime(1989, 07, 28), 
                Color = "Red", 
                Price = 1000d
            };
            Pet pet2 = new Pet()
            {
                Id = 2,
                Name = "Snowball",
                Type = cat,
                BirthDate = new DateTime(1979, 07, 28),
                SoldDate = new DateTime(1989, 07, 28), 
                Color = "Blue", 
                Price = 50d
            };
            _petTable.Add(pet1);
            _petTable.Add(pet2);
        }
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

        public string Delete(int petId)
        {
            _petTable = GetAllPets();
            foreach (var pet in _petTable.ToList())
            {
                if (petId == pet.Id)
                {
                    _petTable.Remove(pet);
                    deletedPetName = pet.Name;
                }
            }
            return deletedPetName;
        }
    }
}