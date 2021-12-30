using PawełGryglewiczLab6PracDom.Models.Dtos.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.Faculty
{

    /// <summary>
    /// Obiekt DTO klasy Faculty do zapytań GET
    /// </summary>
    public class FacultyDtoForGetResponse
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numer wydziału
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Pełna nazwa wydziału
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Lista budynków należących do wydziału
        /// </summary>
        public ICollection<BuildingDtoForFacultyDto> Buildings { get; set; }
    }
}
