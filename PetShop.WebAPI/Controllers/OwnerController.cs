using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        
        [HttpGet]
        public ActionResult<List<Owner>> GetAllOwners()
        {
            return Ok(_ownerService.GetAllOwners());
        }
        
        [HttpGet("{id}")]
        //api/Owner/id
        public ActionResult<Owner> GetById(long id)
        {
            return StatusCode(501, "Vi er ikke klar endnu, ring igen senere bums");
        }
        
        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody]Owner owner)
        {
            return Created($"https://localhost/api/Owner/{owner.Id}",_ownerService.Create(owner));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Owner> DeleteOwner(int id)
        {
            return _ownerService.Delete(id);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Pet> PutOwner(int id, [FromBody] Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest("Id in param must be the same as in object.");
            }
            return Ok(_ownerService.Update(new Owner()
            {
                Id = id,
                Name = owner.Name
            }));
        }
    }
}