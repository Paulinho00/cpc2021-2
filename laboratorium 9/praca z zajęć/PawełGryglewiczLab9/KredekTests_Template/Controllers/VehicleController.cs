using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KredekTests_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public ActionResult<List<Vehicle>> Get()
        {
            return Ok(_vehicleRepository.Get());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetById(int id)
        {
            return Ok(_vehicleRepository.GetById(id));
        }
        
        [HttpPost]
        public ActionResult<Vehicle> Post([FromBody] Vehicle vehicle)
        {
            var result = _vehicleRepository.Add(vehicle);

            return Created(new Uri($"{Request.Path}/{result}",UriKind.Relative) ,result);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Vehicle> Put([FromRoute] int id, [FromBody] Vehicle vehicle)
        {
            if (_vehicleRepository.GetById(id) == null)
            {
                return NotFound();
            }

            var result = _vehicleRepository.Update(vehicle, id);

            return CreatedAtAction("Put",new {id = result.Id},result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_vehicleRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _vehicleRepository.Delete(id);

            return NoContent();
        }
        
    }
}
