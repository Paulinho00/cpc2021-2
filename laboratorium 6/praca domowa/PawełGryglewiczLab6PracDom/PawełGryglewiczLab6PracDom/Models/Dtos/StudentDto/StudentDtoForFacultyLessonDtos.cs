using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto
{
    /// <summary>
    /// Klasa reprezentująca dto dla klasy Student do obiektów dto klasy Faculty
    /// </summary>
    public class StudentDtoForFacultyLessonDtos
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
        /// Numer indeksu
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Nazwa studiowanego kierunku
        /// </summary>
        public string Subject { get; set; }
    }
}
