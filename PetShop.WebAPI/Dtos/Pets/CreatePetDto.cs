using System;

namespace PetShop.WebAPI.Dtos.Pets
{
    public class CreatePetDto
    {
        public string Name{ get; set; }
        public int PetTypeId{ get; set; }
        public DateTime BirthDate{ get; set; }
        public DateTime SoldDate{ get; set; }
        public string Color{ get; set; }
        public double Price{ get; set; }
        public int InsuranceId { get; set; }
    }
}