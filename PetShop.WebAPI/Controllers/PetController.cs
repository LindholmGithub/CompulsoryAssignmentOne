using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.WebAPI.Dtos.Pets;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<List<GetAllPetsDto>> GetAllPets()
        {
            return Ok(_petService.GetAllPets()
                .Select(p => new GetAllPetsDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    PetTypeName = p.Type.Name,
                    BirthDate = p.BirthDate,
                    SoldDate = p.SoldDate,
                    Color = p.Color,
                    Price = p.Price,
                    InsuranceName = p.Insurance.Name
                }));
        }

        [HttpGet("{id}")]
        //api/Pet/id
        public ActionResult<Pet> GetById(long id)
        {
            return StatusCode(501, "Vi er ikke klar endnu, ring igen senere bums");
        }

        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody]CreatePetDto dto)
        {
            var petToCreate = new Pet
            {
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                SoldDate = dto.SoldDate,
                Color = dto.Color,
                Price = dto.Price,
                Type = new PetType
                {
                    Id = dto.PetTypeId
                },
                Insurance = new Insurance
                {
                    Id = dto.InsuranceId
                }
            };
            var petCreated = _petService.Create(petToCreate);
            return Created($"https://localhost/api/Pet/{petCreated.Id}",petCreated);
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> DeletePet(int id)
        {
            return _petService.Delete(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> PutPet(int id, [FromBody] Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest("Id in param must be the same as in object.");
            }
            return Ok(_petService.Update(new Pet()
            {
                Id = id,
                Name = pet.Name,
                Type = pet.Type,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
            }));
        }
    }
}