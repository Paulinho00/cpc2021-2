using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler obsługujący zapytania związane z zapisem na zajęcia
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    public class EnrollController : Controller
    {
        private IEnrollService _enrollService;

        public EnrollController(IEnrollService enrollService)
        {
            _enrollService = enrollService;
        }

        /// <summary>
        /// Endpoint zapytania DELETE usuwający studenta z danych zajęć
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="lessonId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{studentId}/{lessonId}")]
        public IActionResult Delete([FromRoute]int studentId, [FromRoute]int lessonId)
        {
            bool isDone = _enrollService.Delete(studentId, lessonId);
            if (isDone)
            {
                return Ok();
            }
            else
            {
                return NotFound("Nie ma zajęć lub studenta o takim id");
            }
        }

        /// <summary>
        /// Endpoint zapytania POST
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="lessonId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{studentId}/{lessonId}")]
        public IActionResult Post([FromRoute]int studentId, [FromRoute]int lessonId)
        {
            int communicate = _enrollService.Post(studentId, lessonId);
            switch (communicate)
            {
                case -1: return BadRequest("Student ma już zajęcia w tym samym czasie");
                case -2: return BadRequest("Na zajęciach nie ma odpowiedniej liczby wolnych miejsc");
                case -3: return NotFound("Nie znaleziono zajęć lub studenta o danym id");
                default: return Ok();
            }
        }
    }
}
