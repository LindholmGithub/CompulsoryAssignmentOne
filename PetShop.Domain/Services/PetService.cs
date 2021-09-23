using System;
using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepositories _repo;
        private List<Pet> PetList = new List<Pet>();

        public PetService(IPetRepositories repo)
        {
            _repo = repo;
        }

        public List<Pet> GetAllPets()
        {
            return _repo.GetAllPets();
        }

        public List<Pet> GetPetsByType(string searchedWords)
        {
            List<Pet> searchedPets = new List<Pet>();
            PetList = GetAllPets();
            foreach (var pet in PetList)
            {
                if (String.Equals(pet.Type.Name, searchedWords, StringComparison.CurrentCultureIgnoreCase))
                {
                    searchedPets.Add(pet);
                }
            }
            return searchedPets;
        }

        public Pet Create(Pet pet)
        {
            return _repo.Create(pet);
        }

        public Pet Delete(int petId)
        {
            return _repo.Delete(petId);
        }

        public Pet Update(Pet pet)
        {
            return _repo.Update(pet);
        }
    }
}