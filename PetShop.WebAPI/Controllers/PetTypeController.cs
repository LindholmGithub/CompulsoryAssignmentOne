using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        [HttpGet]
        public ActionResult<List<PetType>> GetAllPetTypes()
        {
            return Ok(_petTypeService.GetAllPetTypes());
        }

        [HttpGet("{id}")]
        //api/PetType/id
        public ActionResult<PetType> GetById(long id)
        {
            return StatusCode(501, "Vi er ikke klar endnu, ring igen senere bums");
        }

        [HttpPost]
        public ActionResult<PetType> CreatePetType([FromBody]PetType petType)
        {
            return Created($"https://localhost/api/Pet/{petType.Id}",_petTypeService.Create(petType));
        }

        [HttpDelete("{id}")]
        public ActionResult<PetType> DeletePetType(int id)
        {
            return _petTypeService.Delete(id);
        }

        [HttpPut("{id}")]
        public ActionResult<PetType> PutPetType(int id, [FromBody] PetType petType)
        {
            if (id != petType.Id)
            {
                return BadRequest("Id in param must be the same as in object.");
            }
            return Ok(_petTypeService.Update(new PetType()
            {
                Id = id,
                Name = petType.Name,
            }));
        }
        
    }
}