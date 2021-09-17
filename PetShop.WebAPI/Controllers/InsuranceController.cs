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
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Insurance> GetById(int id)
        {
            try
            {
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
            
        }

        [HttpGet]
        public ActionResult<List<Insurance>> GetAll()
        {
            try
            {
                return Ok(_insuranceService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

        [HttpPost]
        public ActionResult<Insurance> Create([FromBody] Insurance insurance)
        {
            return Ok(_insuranceService.Create(insurance));
        }

        [HttpDelete("{id}")]
        public ActionResult<Insurance> Delete(int id)
        {
            return Ok(_insuranceService.Delete(id));
        }

        [HttpPut("{id}")]
        public ActionResult<Insurance> Update(int id, [FromBody] Insurance insurance)
        {
            try
            {
                if (id != insurance.Id)
                {
                    return BadRequest("Id doesnt match");
                }
                return Ok(_insuranceService.Update(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
            
        }

    }
}