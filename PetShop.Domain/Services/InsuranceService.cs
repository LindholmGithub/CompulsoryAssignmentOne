using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }


        public Insurance GetById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public Insurance Create(Insurance insurance)
        {
            return _insuranceRepository.Create(insurance);
        }

        public List<Insurance> GetAll()
        {
            return _insuranceRepository.GetAll();
        }

        public Insurance Delete(int id)
        {
            return _insuranceRepository.Delete(id);
        }

        public Insurance Update(Insurance insurance)
        {
            return _insuranceRepository.Update(insurance);
        }
    }
}