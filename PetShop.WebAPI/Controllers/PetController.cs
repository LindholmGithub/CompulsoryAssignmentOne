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
    }
}