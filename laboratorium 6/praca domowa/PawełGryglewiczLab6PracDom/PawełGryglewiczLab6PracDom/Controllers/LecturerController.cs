using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler obsługujący zapytania do klasy Lecturer
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        private ILecturerService _lecturerService;

        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        /// <summary>
        /// Endpoint żądania GET zwracający wszystkich prowadzących
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<LecturerDtoForGetResponses>))]
        public IActionResult GetAll()
        {
            var lecturers = _lecturerService.GetAll();
            return Ok(lecturers);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający prowadzącego o danym Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(LecturerDtoForGetResponses))]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var lecturer = _lecturerService.GetById(id);
            if (lecturer == null)
            {
                return NotFound("Nie ma prowadzącego o takim id");
            }
            return Ok(lecturer);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający prowadzących z wydziału o danym id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<LecturerDtoForGetResponses>))]
        [Route("byFacultyId/{facultyId}")]
        public IActionResult GetByFacultyId([FromRoute] int facultyId)
        {
            var lecturers = _lecturerService.GetByFacultyId(facultyId);
            if (lecturers == null)
            {
                return NotFound("Nie ma wydziału o takim id");
            }
            return Ok(lecturers);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający prowadzących z wydziału o danym numerze
        /// </summary>
        /// <param name="facultyNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<LecturerDtoForGetResponses>))]
        [Route("byFacultyNumber/{facultyNumber}")]
        public IActionResult GetByFacultyNumber([FromRoute] int facultyNumber)
        {
            var lecturers = _lecturerService.GetByFacultyNumber(facultyNumber);
            if (lecturers == null)
            {
                return NotFound("Nie ma wydziału o takim numerze");
            }
            return Ok(lecturers);
        }

        /// <summary>
        /// Endpoint żądania DELETE usuwający prowadzącego o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDone = _lecturerService.Delete(id);
            if (isDone)
            {
                return Ok();
            }
            else
            {
                return NotFound("Nie ma prowadzącego o takim id");
            }

        }

        /// <summary>
        /// Endpoint żądania PUT edytujący dane prowadzącego o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lecturerDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]LecturerDtoForPostPutResponses lecturerDto)
        {
            int communicate = _lecturerService.Put(id, lecturerDto);
            switch (communicate)
            {
                case -1: return BadRequest("Numer PESEL ma nieodpowiednią długość lub zawiera niedozwolone znaki");
                case -2: return BadRequest("Wydział o takim Id nie istnieje");
                case -3: return NotFound("Nie znaleziono prowadzącego o takim id");
                case -4: return BadRequest("Numer PESEL nie jest unikalny");
                case -5: return BadRequest("Nie wszystkie pola są wypełnione");
                case -6: return BadRequest("Pola z imieniem, nazwiskiem lub stopniem zawierają niedozwolone znaki");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint żądania POST dodający nowego prowadzącego
        /// </summary>
        /// <param name="lecturerDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]LecturerDtoForPostPutResponses lecturerDto)
        {
            int communicate = _lecturerService.Post(lecturerDto);
            switch (communicate)
            {
                case -1: return BadRequest("Numer PESEL ma nieodpowiednią długość lub zawiera niedozwolone znaki");
                case -2: return BadRequest("Wydział o takim Id nie istnieje");
                case -4: return BadRequest("Numer PESEL nie jest unikalny");
                case -5: return BadRequest("Nie wszystkie pola są wypełnione");
                case -6: return BadRequest("Pola z imieniem, nazwiskiem lub stopniem zawierają niedozwolone znaki");
                default: return Ok();
            }
        }


    }
}
