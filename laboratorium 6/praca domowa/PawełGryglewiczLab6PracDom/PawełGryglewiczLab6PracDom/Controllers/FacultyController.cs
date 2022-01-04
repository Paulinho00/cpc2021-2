using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos;
using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using PawełGryglewiczLab6PracDom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler do klasy Faculty
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        /// <summary>
        /// Endpoint GET zwracający wszystkie wydziały
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<FacultyDtoForGetResponse>))]
        public IActionResult GetAll()
        {
            var faculties = _facultyService.GetAll();
            return Ok(faculties);
        }

        /// <summary>
        /// Endpoint GET zwracający wydział o danym Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(FacultyDtoForGetResponse))]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var faculty = _facultyService.GetById(id);

            //Sprawdzenie czy wydział istnieje
            if (faculty == null)
            {
                return NotFound("Nie ma wydziału z takim id");
            }

            return Ok(faculty);


        }

        /// <summary>
        /// Endpoint POST dodający nowy wydział
        /// </summary>
        /// <param name="facultyDto">Nowy wydział</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] FacultyDtoForPostPutResponse facultyDto)
        {
            int communicate = _facultyService.Post(facultyDto);

            //Wysłanie odpowiedniego komunikatu
            switch (communicate)
            {
                case -1: return BadRequest("Nazwa wydziału powtarza się");
                case -2: return BadRequest("Numer wydziału powtarza się");
                case -3: return BadRequest("Numer wydziału nie mieści się w zakresie od 1 do 20");
                case -5: return BadRequest("Nie wszystkie pola są wypełnione");
                case -6: return BadRequest("Pole z nazwą zawiera nieodpowiednie znaki");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint PUT edytujący wydział o podanym id
        /// </summary>
        /// <param name="facultyDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromBody] FacultyDtoForPostPutResponse facultyDto, [FromRoute] int id)
        {
            int communicate = _facultyService.Put(id, facultyDto);

            //Wysłanie odpowiedniego komunikatu
            switch (communicate)
            {
                case -1: return BadRequest("Nazwa wydziału powtarza się");
                case -2: return BadRequest("Numer wydziału powtarza się");
                case -3: return BadRequest("Numer wydziału nie mieści się w zakresie od 1 do 20");
                case -4: return NotFound("Nie ma wydziału o takim id");
                case -5: return BadRequest("Nie wszystkie pola są wypełnione");
                case -6: return BadRequest("Pole z nazwą zawiera nieodpowiednie znaki");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint DELETE usuwający wydział o podanym id
        /// </summary>
        /// <param name="id">id wydziału</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Sprawdzenie czy operacja została wykonana
            bool isDone = _facultyService.DeleteById(id);
            if (isDone)
            {
                return Ok();
            }
            return NotFound("Nie ma wydziału z takim id");
        }

    }
}
