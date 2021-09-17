using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IInsuranceService
    {
        public Insurance GetById(int id);
        public Insurance Create(Insurance insurance);
        public List<Insurance> GetAll();
        public Insurance Delete(int id);
        public Insurance Update(Insurance insurance);
    }
}