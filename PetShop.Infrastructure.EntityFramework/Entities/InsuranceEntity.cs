using System.Collections.Generic;

namespace PetShop.Infrastructure.EntityFramework.Entities
{
    public class InsuranceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<PetEntity> Pets { get; set; }
    }
}