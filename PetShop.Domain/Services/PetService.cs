using System;
using System.Collections.Generic;
using PetShop.Core.Filter;
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

        public FilteredList<Pet> GetAllPets(Filter filter)
        {
            if (filter == null || filter.Limit <= 0 || filter.Limit > 100)
            {
                throw new ArgumentException("Filter Limit must be between 1 and 100");
            }

            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double)totalCount / filter.Limit);
            if (filter.Page < 1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException($"Filter Page must be between 1 and {maxPageCount}");
            }
            var listOfAllPets = _repo.GetAllPets(filter);
            return new FilteredList<Pet>()
            {
                List = listOfAllPets,
                TotalCount = totalCount
            };
        }


        public List<Pet> GetPetsByType(string searchedWords)
        {
            /*List<Pet> searchedPets = new List<Pet>();
            var filter = new Filter();
            PetList = GetAllPets(filter);
            foreach (var pet in PetList)
            {
                if (String.Equals(pet.Type.Name, searchedWords, StringComparison.CurrentCultureIgnoreCase))
                {
                    searchedPets.Add(pet);
                }
            }
            return searchedPets;
            */
            throw new NotImplementedException();
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

        public int TotalCount()
        {
            return _repo.TotalCount();
        }
    }
}