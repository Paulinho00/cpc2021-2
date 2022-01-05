using PawełGryglewiczLab6PracDom.Models.Dtos.FacultyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto
{
    /// <summary>
    /// Klasa reprezentująca dto klasy Lecturer dla dto klasy Lesson
    /// </summary>
    public class LecturerDtoForLessonDto
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Imię prowadzącego
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko prowadzącego
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Stopień naukowy
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// Obiekt wydziału, na którym pracuje prowadzący
        /// </summary>
        public FacultyDtoForLecturerStudentBuildingDtos Faculty { get; set; }
    }
}
