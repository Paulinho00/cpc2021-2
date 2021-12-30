
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.Building
{
    /// <summary>
    /// Klasa reprezentująca dto dla klasy Building do obiektów Dto klasy Faculty
    /// </summary>
    public class BuildingDtoForFacultyDto
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
        /// Liczba pięter
        /// </summary>
        public int NumberOfFloors { get; set; }
    }
}
