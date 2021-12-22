using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6.Models;
using PawełGryglewiczLab6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController: ControllerBase
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        [Produces(typeof(List<Pizza>))]
        public IActionResult GetAllPizza() 
        {
            var pizzas = _pizzaService.Get();
            return Ok(pizzas);
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Pizza pizza)
        {
            int id = _pizzaService.Post(pizza);
            return Ok(id);
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Put([FromRoute] int id, [FromBody] Pizza pizza)
        {
            if(id != pizza.Id)
            {
                return Conflict("Podane id są różne");
            }

            var isUpdateSuccesfull = _pizzaService.Put(id, pizza);

            if (isUpdateSuccesfull) 
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _pizzaService.Delete(id);
            if (result)
                return NoContent();

            return NotFound();
        }
    }
            
}
