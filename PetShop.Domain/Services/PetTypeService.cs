using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepositories _petTypeRepository;

        public PetTypeService(IPetTypeRepositories petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepository.GetAllPetTypes();
        }

        public PetType GetById(int id)
        {
            return _petTypeRepository.ReadById(id);
        }

        public PetType Create(PetType petType)
        {
            return _petTypeRepository.Create(petType);
        }

        public PetType Delete(int petTypeId)
        {
            return _petTypeRepository.Delete(petTypeId);
        }

        public PetType Update(PetType petType)
        {
            return _petTypeRepository.Update(petType);
        }
    }
}