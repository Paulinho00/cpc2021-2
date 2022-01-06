using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler zapytań związanych z klasą Lesson
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LessonController : Controller
    {

        private ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        /// <summary>
        /// Endpoint zapytania GET zwracający wszystkie zajęcia zapisane w bazie danych
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<LessonDtoForGetResponses>))]
        public IActionResult GetAll()
        {
            var lessons = _lessonService.GetAll();
            return Ok(lessons);
        }

        /// <summary>
        /// Endpoint zapytania GET zwracający zajęcia o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(LessonDtoForGetResponses))]
        [Route("byId/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var lesson = _lessonService.GetById(id);
            if (lesson == null)
            {
                return NotFound("Nie ma zajęć o takim id");
            }
            return Ok(lesson);
        }

        /// <summary>
        /// Endpoint zapytania GET zwracający wszystkie zajęcia przypisane do danego prowadzącego
        /// </summary>
        /// <param name="lecturedId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byLecturerId/{lecturedId}")]
        [Produces(typeof(List<LessonDtoForGetResponses>))]
        public IActionResult GetByLecturerId([FromRoute] int lecturedId)
        {
            var lessons = _lessonService.GetByLecturerId(lecturedId);
            if (lessons == null)
            {
                return NotFound("Nie znaleziono zajęć przypisanych do tego prowadzącego");
            }
            return Ok(lessons);
        }

        /// <summary>
        /// Endpoint zapytania GET zwracający wszystkie zajęcia odbywające się w danej sali
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byRoomId/{roomId}")]
        [Produces(typeof(List<LessonDtoForGetResponses>))]
        public IActionResult GetByRoomId([FromRoute] int roomId)
        {
            var lessons = _lessonService.GetByRoomId(roomId);
            if (lessons == null)
            {
                return NotFound("Nie znaleziono zajęć przypisanych do tego prowadzącego");
            }
            return Ok(lessons);
        }

        /// <summary>
        /// Endpoint zapytania DELETE usuwający zajęcia o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool isDone = _lessonService.Delete(id);
            if (isDone)
            {
                return Ok();
            }
            else
            {
                return NotFound("Nie ma zajęć o takim id");
            }
        }

        /// <summary>
        /// Endpoint zapytania PUT edytujący zajęcia o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lessonDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] LessonDtoForPostPutResponses lessonDto)
        {
            int communicate = _lessonService.Put(id, lessonDto);
            switch (communicate)
            {
                case -1: return BadRequest("Data zajęć nie może być wcześniejsza niż dzisiejsza");
                case -2: return BadRequest("Nie wszystkie pola są wypełnione");
                case -3: return BadRequest("Prowadzący o danym id nie istnieje");
                case -4: return BadRequest("Prowadzący o danym id ma już zajęcia w tym czasie");
                case -5: return BadRequest("Sala przypisywana do zajęć nie istnieje");
                case -6: return BadRequest("Wybrana sala jest już zajęta w przez inne zajęcia w danym czasie");
                case -7: return NotFound("Nie ma zajęć o takim id");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint żądania POST dodający nowe zajęcia
        /// </summary>
        /// <param name="lessonDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(LessonDtoForPostPutResponses lessonDto)
        {
            int communicate = _lessonService.Post(lessonDto);
            switch (communicate)
            {
                case -1: return BadRequest("Data zajęć nie może być wcześniejsza niż dzisiejsza");
                case -2: return BadRequest("Nie wszystkie pola są wypełnione");
                case -3: return BadRequest("Prowadzący o danym id nie istnieje");
                case -4: return BadRequest("Prowadzący o danym id ma już zajęcia w tym czasie");
                case -5: return BadRequest("Sala przypisywana do zajęć nie istnieje");
                case -6: return BadRequest("Wybrana sala jest już zajęta w przez inne zajęcia w danym czasie");
                default: return Ok();
            }
        }
    }
}
