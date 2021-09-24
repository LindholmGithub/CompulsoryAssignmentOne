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
            if (pet.Type == null || pet.Type.Id < 1)
            {
                throw new ArgumentException("Woops, PetType must exist and PetType ID must be 1 or above");
            }
            if (pet.Insurance == null || pet.Insurance.Id < 1)
            {
                throw new ArgumentException("Woops, Insurance must exist and Insurance ID must be 1 or above");
            }
            return _repo.Create(pet);
        }

        public Pet Delete(int petId)
        {
            return _repo.Delete(petId);
        }

        public Pet Update(Pet pet)
        {
            if (pet.Type == null || pet.Type.Id < 1)
            {
                throw new ArgumentException("Woops, PetType must exist and PetType ID must be 1 or above");
            }

            if (pet.Insurance == null || pet.Insurance.Id < 1)
            {
                throw new ArgumentException("Woops, Insurance must exist and Insurance ID must be 1 or above");
            }
            return _repo.Update(pet);
        }
    }
}