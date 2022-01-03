using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto
{
    /// <summary>
    /// Klasa reprezentująca Dto klasy Student do poleceń POST i PUT
    /// </summary>
    public class StudentDtoForPostPutResponses
    {
        /// <summary>
        /// Imię studenta
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko studenta
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Numer PESEL 
        /// </summary>
        public string Pesel { get; set; }

        /// <summary>
        /// Numer indeksu
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Id wydziału, na którym student studiuje
        /// </summary>
        public int FacultyId { get; set; }

        /// <summary>
        /// Nazwa studiowanego kierunku
        /// </summary>
        public string Subject { get; set; }
    }
}
