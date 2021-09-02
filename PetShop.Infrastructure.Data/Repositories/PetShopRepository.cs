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

        private static int _petId = 7;

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
            PetType goat = new PetType
            {
                Name = "Goat",
                Id = 3
            };
            PetType snake = new PetType
            {
                Name = "Snake",
                Id = 4
            };
            PetType bird = new PetType
            {
                Name = "Bird",
                Id = 5
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
            Pet pet3 = new Pet()
            {
                Id = 3,
                Name = "Billy",
                Type = goat,
                BirthDate = new DateTime(1999, 12, 02),
                SoldDate = new DateTime(1999, 12, 28), 
                Color = "Black", 
                Price = 500000d
            };
            Pet pet4 = new Pet()
            {
                Id = 4,
                Name = "Solid",
                Type = snake,
                BirthDate = new DateTime(2013, 05, 30),
                SoldDate = new DateTime(2014, 06, 01), 
                Color = "Green", 
                Price = 10.99d
            };
            Pet pet5 = new Pet()
            {
                Id = 5,
                Name = "Tweetie",
                Type = bird,
                BirthDate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09), 
                Color = "Yellow", 
                Price = 888.88d
            };
            Pet pet6 = new Pet()
            {
                Id = 6,
                Name = "Garry",
                Type = goat,
                BirthDate = new DateTime(2000, 07, 28),
                SoldDate = new DateTime(2001, 07, 28), 
                Color = "Gold", 
                Price = 500001d
            };
            _petTable.Add(pet1);
            _petTable.Add(pet2);
            _petTable.Add(pet3);
            _petTable.Add(pet4);
            _petTable.Add(pet5);
            _petTable.Add(pet6);
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

        public void UpdateName(int idToUpdate, string newPetName)
        {
            List<Pet> allPets = _petTable;
            allPets.First(pet => pet.Id == idToUpdate).Name = newPetName;
        }

        public void UpdatePetType(int idToUpdate, string newPetType)
        {
            List<Pet> allPets = _petTable;
            allPets.First(pet => pet.Id == idToUpdate).Type.Name = newPetType;
        }

        public void UpdatePetBirthDate(int idToUpdate, DateTime newPetBirthDate)
        {
            List<Pet> allPets = _petTable;
            allPets.First(pet => pet.Id == idToUpdate).BirthDate = newPetBirthDate;
        }

        public void UpdatePetSoldDate(int idToUpdate, DateTime newPetSoldDate)
        {
            List<Pet> allPets = _petTable;
            allPets.First(pet => pet.Id == idToUpdate).SoldDate = newPetSoldDate;
        }

        public void UpdatePetColor(int idToUpdate, string newPetColor)
        {
            List<Pet> allPets = _petTable;
            allPets.First(pet => pet.Id == idToUpdate).Color = newPetColor;
        }

        public void UpdatePetPrice(int idToUpdate, double newPetPrice)
        {
            List<Pet> allPets = _petTable;
            allPets.First(pet => pet.Id == idToUpdate).Price = newPetPrice;
        }
    }
}