using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto
{
    /// <summary>
    /// Klasa reprezentująca dto dla klasy Faculty do obiektów dto klasy Lecturer
    /// </summary>
    public class FacultyDtoForLecturerDto
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
    }
}
