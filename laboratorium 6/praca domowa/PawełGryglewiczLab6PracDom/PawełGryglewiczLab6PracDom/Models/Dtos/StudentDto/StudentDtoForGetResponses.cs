using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto
{
    /// <summary>
    /// Klasa reprezentująca Dto klasy Student do poleceń GET
    /// </summary>
    public class StudentDtoForGetResponses
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

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
        /// Nazwa studiowanego kierunku
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Obiekt wydziału, na którym studiuje student
        /// </summary>
        public FacultyDtoForLecturerStudentBuildingDtos Faculty { get; set; }
    }
}
