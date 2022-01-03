using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto
{
    /// <summary>
    /// Klasa reprezentująca Dto klasy Lecturer do poleceń POST i PUT
    /// </summary>
    public class LecturerDtoForPostPutResponses
    {
        /// <summary>
        /// Imię prowadzącego
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko prowadzącego
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Numer PESEL
        /// </summary>
        public string Pesel { get; set; }

        /// <summary>
        /// Stopień naukowy
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// Id wydziału, na którym pracuje prowadzący
        /// </summary>
        public int FacultyId { get; set; }
    }
}
