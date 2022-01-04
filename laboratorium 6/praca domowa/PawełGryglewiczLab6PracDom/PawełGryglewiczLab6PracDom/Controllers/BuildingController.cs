using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto;
using PawełGryglewiczLab6PracDom.Services;
using PawełGryglewiczLab6PracDom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Controllers
{
    /// <summary>
    /// Kontroler do klasy Building
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        private IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        /// <summary>
        /// Endpoint żadania GET zwracające wszystkie buldynki
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(List<BuildingDtoForGetResponse>))]
        public IActionResult GetAll()
        {
            var buildings = _buildingService.GetAll();
            return Ok(buildings);
        }

        /// <summary>
        /// Endpoint żądania GET zwracające budynki należące do danego wydziału
        /// </summary>
        /// <param name="facultyId">Id wydziału</param>
        /// <returns></returns>
        [HttpGet]
        [Route("byFaculty/{facultyId}")]
        [Produces(typeof(List<BuildingDtoForGetResponse>))]
        public IActionResult GetByFacultyId([FromRoute] int facultyId)
        {
            var buildings = _buildingService.GetByFaculty(facultyId);

            //Sprawdzenie czy operacja powiodła się
            if (buildings == null)
            {
                return NotFound("Nie ma wydziału o takim id");
            }
            return Ok(buildings);
        }


        /// <summary>
        /// Endpoint żadania GET zwracający budynek z danej kategorii i o danym numerze
        /// </summary>
        /// <param name="category">Kategoria budynku</param>
        /// <param name="number">Numer budynku</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{category}/{number}")]
        [Produces(typeof(BuildingDtoForGetResponse))]
        public IActionResult GetByCategoryAndNumber([FromRoute] char category, [FromRoute] int number)
        {
            var building = _buildingService.GetByCategoryAndNumber(category, number);

            //Sprawdzenie czy operacja powiodła się
            if (building == null)
            {
                return NotFound("Nie ma takiego budynku");
            }

            return Ok(building);
        }


        /// <summary>
        /// Endpoint żądania GET zwracający budynek o danym id
        /// </summary>
        /// <param name="id">Id budynku</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces(typeof(BuildingDtoForGetResponse))]
        public IActionResult GetById([FromRoute] int id)
        {
            var building = _buildingService.GetById(id);

            //Sprawdzenie czy operacja powiodła się
            if (building == null)
            {
                return NotFound("Nie ma budynku o takim id");
            }

            return Ok(building);
        }

        /// <summary>
        /// Endpoint żadania DELETE usuwający budynek o danym id
        /// </summary>
        /// <param name="id">Id usuwanego budynku</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            bool isDone = _buildingService.DeleteById(id);

            //Sprawdzenie czy operacja powiodła się
            if (isDone)
            {
                return Ok();
            }
            return NotFound("Nie ma budynku o takim id");
        }

        /// <summary>
        /// Endpoint żadania DELETE usuwający budynek z danej kategori i o danym numerze
        /// </summary>
        /// <param name="category">Kategoria budynku</param>
        /// <param name="number">Numer budynku</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{category}/{number}")]
        public IActionResult DeleteByCategoryAndNumber([FromRoute] char category, [FromRoute] int number)
        {
            bool isDone = _buildingService.DeleteByCategoryAndNumber(category, number);

            //Sprawdzenie czy operacja powiodła się
            if (isDone)
            {
                return Ok();
            }
            return NotFound("Nie ma takiego budynku");
        }

        /// <summary>
        /// Endpoint żadania POST, tworzący nowy budynek
        /// </summary>
        /// <param name="buildingDto">obiekt utworzonego budynku</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] BuildingDtoForPostPutResponse buildingDto)
        {
            int communicate = _buildingService.Post(buildingDto);
            //Wysłanie odpowiedniego komunikatu
            switch (communicate)
            {
                case -1: return BadRequest("Numer budynku w danej kategorii musi być unikalny");
                case -2: return BadRequest("Wydział przypisany do danego budynku nie istnieje");
                case -4: return BadRequest("Podany rok budowy nie mieści się w odpowiednim zakresie (od 1900 do 2021)");
                case -5: return BadRequest("Podana liczba pięter nie mieści się w zakresie od 1 do 20");
                case -6: return BadRequest("Kategoria nie jest literą");
                case -7: return BadRequest("Numer musi być >0");
                default: return Ok();
            }

        }

        /// <summary>
        /// Endpoint żadania PUT, edytujący budynek o danym id
        /// </summary>
        /// <param name="id">Id edytowanego budynku</param>
        /// <param name="buildingDto">Zmodyfikowany obiekt budynku</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] BuildingDtoForPostPutResponse buildingDto)
        {
            int communicate = _buildingService.Put(id, buildingDto);
            //Wysłanie odpowiedniego komunikatu
            switch (communicate)
            {
                case -1: return BadRequest("Numer budynku w danej kategorii musi być unikalny");
                case -2: return BadRequest("Wydział przypisany do danego budynku nie istnieje");
                case -3: return NotFound("Nie ma budynku o takim id");
                case -4: return BadRequest("Podany rok budowy nie mieści się w odpowiednim zakresie (od 1900 do 2021)");
                case -5: return BadRequest("Podana liczba pięter nie mieści się w zakresie od 1 do 20");
                case -6: return BadRequest("Kategoria nie jest literą");
                case -7: return BadRequest("Numer musi być >0");
                default: return Ok();
            }
        }
    }
}
