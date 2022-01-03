using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler obsługujący zapytania do klasy Student
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Endpoint żądania GET zwracający dane wszystkich studentów
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<StudentDtoForGetResponses>))]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający dane studenta o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(StudentDtoForGetResponses))]
        [Route("byId/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound("Nie ma studenta o takim id");
            }
            return Ok(student);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający studentów studiujących na wydziale o danym id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<StudentDtoForGetResponses>))]
        [Route("byFacultyId/{facultyId}")]
        public IActionResult GetByFacultyId([FromRoute] int facultyId)
        {
            var students = _studentService.GetByFacultyId(facultyId);
            if (students == null)
            {
                return NotFound("Nie ma wydziału o takim id");
            }
            return Ok(students);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający studentów studiujących na wydziale o danym numerze 
        /// </summary>
        /// <param name="facultyNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<StudentDtoForGetResponses>))]
        [Route("byFacultyNumber/{facultyNumber}")]
        public IActionResult GetByFacultyNumber([FromRoute] int facultyNumber)
        {
            var students = _studentService.GetByFacultyNumber(facultyNumber);
            if (students == null)
            {
                return NotFound("Nie ma wydziału o takim numerze");
            }

            return Ok(students);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający dane studenta o danym indeksie
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(StudentDtoForGetResponses))]
        [Route("byIndex/{index}")]
        public IActionResult GetByIndex([FromRoute] int index)
        {
            var student = _studentService.GetByIndex(index);
            if (student == null)
            {
                return NotFound("Nie ma studenta z takim indeksem");
            }
            return Ok(student);
        }

        /// <summary>
        /// Endpoint żądania DELETE usuwający studenta o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("byId/{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            bool isDone = _studentService.DeleteById(id);
            if (isDone)
            {
                return Ok();
            }
            else
            {
                return NotFound("Nie ma studenta o takim id");
            }
        }

        /// <summary>
        /// Endpoint żądania DELETE usuwający studenta o danym indeksie
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("byIndex/{index}")]
        public IActionResult DeleteByIndex([FromRoute] int index)
        {
            bool isDone = _studentService.DeleteByIndex(index);
            if (isDone)
            {
                return Ok();
            }
            else
            {
                return NotFound("Nie ma studenta o takim indeksie");
            }
        }

        /// <summary>
        /// Endpoint żądania PUT, zmieniający dane studenta o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("byId/{id}")]
        public IActionResult PutById([FromRoute] int id, [FromBody] StudentDtoForPostPutResponses studentDto)
        {
            int communicate = _studentService.PutById(id, studentDto);
            switch (communicate)
            {
                case -1: return BadRequest("Nie zgadza się długość PESEL lub zawiera niedozwolne znaki");
                case -2: return BadRequest("Numer PESEL nie jest unikalny");
                case -3: return BadRequest("Numer indeksu nie mieści się w zakresie od 200001 do 299999");
                case -4: return BadRequest("Numer indeksu nie jest unikalny");
                case -5: return BadRequest("Nie ma wydziału o takim id");
                case -6: return NotFound("Nie ma studenta o takim id");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint żądania PUT, zmieniający dane studenta o danym indeksie
        /// </summary>
        /// <param name="index"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("byIndex/{index}")]
        public IActionResult PutByIndex([FromRoute] int index, [FromBody] StudentDtoForPostPutResponses studentDto)
        {
            int communicate = _studentService.PutByIndex(index, studentDto);
            switch (communicate)
            {
                case -1: return BadRequest("Nie zgadza się długość PESEL lub zawiera niedozwolne znaki");
                case -2: return BadRequest("Numer PESEL nie jest unikalny");
                case -3: return BadRequest("Numer indeksu nie mieści się w zakresie od 200001 do 299999");
                case -4: return BadRequest("Numer indeksu nie jest unikalny");
                case -5: return BadRequest("Nie ma wydziału o takim id");
                case -6: return NotFound("Nie ma studenta o takim indeksie");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint żądania POST, dodający nowego studenta
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]StudentDtoForPostPutResponses studentDto)
        {
            int communicate = _studentService.Post(studentDto);
            switch (communicate)
            {
                case -1: return BadRequest("Nie zgadza się długość PESEL lub zawiera niedozwolne znaki");
                case -2: return BadRequest("Numer PESEL nie jest unikalny");
                case -3: return BadRequest("Numer indeksu nie mieści się w zakresie od 200001 do 299999");
                case -4: return BadRequest("Numer indeksu nie jest unikalny");
                case -5: return BadRequest("Nie ma wydziału o takim id");
                default: return Ok();
            }
        }
    }
}
