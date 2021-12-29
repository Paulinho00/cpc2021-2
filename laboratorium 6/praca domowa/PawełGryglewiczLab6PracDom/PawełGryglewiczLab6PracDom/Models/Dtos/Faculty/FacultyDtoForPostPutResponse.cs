using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.Faculty
{
    /// <summary>
    /// Klasa odpowiadająca DTO klasy Faculty dla zapytań Post i Put
    /// </summary>
    public class FacultyDtoForPostPutResponse
    {
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
