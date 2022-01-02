using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto
{
    /// <summary>
    /// Klasa reprezentująca Dto klasy Building do poleceń GET
    /// </summary>
    public class BuildingDtoForGetResponse
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Kategoria budynku
        /// </summary>
        public char Category { get; set; }

        /// <summary>
        /// Numer budynku
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Rok budowy
        /// </summary>
        public int YearOfBuild { get; set; }

        /// <summary>
        /// Obiekt wydziału do którego należy budynek
        /// </summary>
        public FacultyDtoForGetResponse Faculty { get; set; }

        /// <summary>
        /// Liczba pięter
        /// </summary>
        public int NumberOfFloors { get; set; }

        /// <summary>
        /// Sale, które znajdują się w budynku
        /// </summary>
        public ICollection<RoomDtoForBuildingDto> Rooms { get; set; }
    }
}
