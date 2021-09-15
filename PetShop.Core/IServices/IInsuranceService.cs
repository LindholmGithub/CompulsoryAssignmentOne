using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IInsuranceService
    {
        public Insurance GetById(int id);
        Insurance Create(Insurance insurance);
    }
}