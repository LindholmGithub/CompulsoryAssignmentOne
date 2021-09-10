using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;

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
        public ActionResult<List<Pet>> getAllPets()
        {
            return Ok(_petService.GetAllPets());
        }

        [HttpGet("{id}")]
        //api/Pet/id
        //api/Pet/7
        public ActionResult<Pet> GetById(long id)
        {
            return StatusCode(501, "Vi er ikke klar endnu, ring igen senere bums");
        }

        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody]Pet pet)
        {
            return Created($"https://localhost/api/Pet/{pet.Id}",_petService.Create(pet));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeletePet(int id)
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
            _petService.UpdatePetName(pet.Id, pet.Name);
            _petService.UpdatePetType(pet.Id, pet.Type.Name);
            _petService.UpdatePetBirthDate(pet.Id, pet.BirthDate);
            _petService.UpdatePetSoldDate(pet.Id, pet.SoldDate);
            _petService.UpdatePetColor(pet.Id, pet.Color);
            _petService.UpdatePetPrice(pet.Id, pet.Price);
            return Ok();
        }
    }
}