using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto
{
    /// <summary>
    /// Klasa reprezentująca dto dla klasy Building do obiektów Dto klasy Room
    /// </summary>
    public class BuildingDtoForRoomDto
    {
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

    }
}
