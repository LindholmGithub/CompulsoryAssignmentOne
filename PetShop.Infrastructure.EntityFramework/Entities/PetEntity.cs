using System;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.EntityFramework.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name{ get; set; }

        public int PetEntityId { get; set; }
        public PetTypeEntity Type { get; set; }
        public DateTime BirthDate{ get; set; }
        public DateTime SoldDate{ get; set; }
        public string Color{ get; set; }
        public double Price{ get; set; }
        public int InsuranceID { get; set; }
        public InsuranceEntity Insurance { get; set; }
    }
}