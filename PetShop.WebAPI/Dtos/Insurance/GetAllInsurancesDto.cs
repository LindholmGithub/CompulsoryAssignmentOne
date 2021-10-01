using System.Collections.Generic;

namespace PetShop.WebAPI.Dtos.Insurance
{
    public class GetAllInsurancesDto
    {
        public List<GetInsuranceDto> Insurances { get; set; }

    }
}