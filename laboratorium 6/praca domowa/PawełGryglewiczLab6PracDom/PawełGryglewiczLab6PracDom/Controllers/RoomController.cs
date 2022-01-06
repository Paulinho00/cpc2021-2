using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler do klasy Room
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Endpoint GET zwracający wszystkie sale
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<RoomDtoForGetResponses>))]
        public IActionResult GetAll()
        {
            var rooms = _roomService.GetAll();
            
            return Ok(rooms);
        }

        /// <summary>
        /// Endpoint żadania GET zwracający salę o danym Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(RoomDtoForGetResponses))]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
            {
                return NotFound("Nie ma sali z takim id");
            }
            return Ok(room);
        }

        /// <summary>
        /// Endpoint żadania GET zwracający salę o danym numerze w danym budybnku
        /// </summary>
        /// <param name="category"></param>
        /// <param name="buildingNumber"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(RoomDtoForGetResponses))]
        [Route("{category}/{buildingNumber}/{roomNumber}")]
        public IActionResult GetByNumber([FromRoute] char category, [FromRoute] int buildingNumber, [FromRoute] int roomNumber)
        {
            var room = _roomService.GetByNumber(category, buildingNumber, roomNumber);
            if (room == null)
            {
                return NotFound("Nie ma takiej sali");
            }
            return Ok(room);
        }

        /// <summary>
        /// Endpoint żądania GET zwracający sale w danym budynku
        /// </summary>
        /// <param name="category"></param>
        /// <param name="buildingNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<RoomDtoForGetResponses>))]
        [Route("{category}/{buildingNumber}")]
        public IActionResult GetByBuilding([FromRoute] char category, [FromRoute] int buildingNumber)
        {
            var rooms = _roomService.GetByBuilding(category, buildingNumber);
            if (rooms == null)
            {
                return NotFound("Nie ma takiego budynku");
            }
            return Ok(rooms);
        }

        /// <summary>
        /// Endpoint żadania DELETE usuwający salę o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            bool isDone = _roomService.DeleteById(id);
            if (isDone)
            {
                return Ok();
            }
            return NotFound("Nie ma sali o takim id");
        }

        /// <summary>
        /// Endpoint żądania DELETE usuwający salę o danym numerze w danym budynku
        /// </summary>
        /// <param name="category"></param>
        /// <param name="buildingNumber"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{category}/{buildingNumber}/{roomNumber}")]
        public IActionResult DeleteByNumber([FromRoute] char category, [FromRoute] int buildingNumber, [FromRoute] int roomNumber)
        {
            bool isDone = _roomService.DeleteByNumber(category, buildingNumber, roomNumber);
            if (isDone)
            {
                return Ok();
            }
            return NotFound("Nie znaleziono takiej sali");
        }

        /// <summary>
        /// Endpoint żądania PUT edytujący salę o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult PutById([FromRoute] int id, [FromBody] RoomDtoForPostPutResponses roomDto)
        {
            int communicate = _roomService.PutById(id, roomDto);
            switch (communicate)
            {
                case -1: return NotFound("Nie znaleziono takiej sali");
                case -2: return BadRequest("Budynek, do którego przypisywana jest sala, nie istnieje");
                case -3: return BadRequest("Numer sali powtarza się w obrębie wybranego budynku");
                case -4: return BadRequest("Nie ma takiego piętra w budynku");
                case -5: return BadRequest("Numer sali nie jest poprawny");
                case -6: return BadRequest("Liczba miejsc nie jest poprawna (nie jest >=2)");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint żądania PUT edytujący salę o danym numerze w danym budynku
        /// </summary>
        /// <param name="category"></param>
        /// <param name="buildingNumber"></param>
        /// <param name="roomNumber"></param>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{category}/{buildingNumber}/{roomNumber}")]
        public IActionResult PutByNumber([FromRoute] char category, [FromRoute] int buildingNumber, [FromRoute] int roomNumber, [FromBody] RoomDtoForPostPutResponses roomDto)
        {
            int communicate = _roomService.PutByNumber(category, buildingNumber, roomNumber, roomDto);
            switch (communicate)
            {
                case -1: return NotFound("Nie znaleziono takiej sali");
                case -2: return BadRequest("Budynek, do którego przypisywana jest sala, nie istnieje");
                case -3: return BadRequest("Numer sali powtarza się w obrębie wybranego budynku");
                case -4: return BadRequest("Nie ma takiego piętra w budynku");
                case -5: return BadRequest("Numer sali nie jest poprawny");
                case -6: return BadRequest("Liczba miejsc nie jest poprawna (nie jest >=2)");
                default: return Ok();
            }
        }

        /// <summary>
        /// Endpoint żądania POST dodający nową salę
        /// </summary>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]RoomDtoForPostPutResponses roomDto)
        {
            int communicate = _roomService.Post(roomDto);
            switch (communicate)
            {
                case -2: return BadRequest("Budynek, do którego przypisywana jest sala, nie istnieje");
                case -3: return BadRequest("Numer sali powtarza się w obrębie wybranego budynku");
                case -4: return BadRequest("Nie ma takiego piętra w budynku");
                case -5: return BadRequest("Numer sali nie jest poprawny");
                case -6: return BadRequest("Liczba miejsc nie jest poprawna (nie jest >=2)");
                default: return Ok();
            }
        }
    }
}
