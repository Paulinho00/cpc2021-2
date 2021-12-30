using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.Building
{
    /// <summary>
    /// Klasa reprezentująca Dto klasy Bulding do poleceń POST i GET
    /// </summary>
    public class BuildingDtoForPostPutResponse
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

        /// <summary>
        /// Wydział do którego należy budynek
        /// </summary>
        public int FacultyFK { get; set; }

        /// <summary>
        /// Liczba pięter
        /// </summary>
        public int NumberOfFloors { get; set; }
    }
}
