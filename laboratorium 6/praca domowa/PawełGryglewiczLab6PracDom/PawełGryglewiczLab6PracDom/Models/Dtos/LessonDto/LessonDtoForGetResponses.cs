using PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
using PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto
{
    /// <summary>
    /// Klasa reprezentująca dto klasy Lesson do zapytań GET
    /// </summary>
    public class LessonDtoForGetResponses
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data zajęć
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Przedmiot, którego dotyczą zajęcia
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Obiekt prowadzącego zajęcia
        /// </summary>
        public LecturerDtoForLessonDto Lecturer { get; set; }

        /// <summary>
        /// Obiekt pomieszczenia, w którym odbywają się zajęcia
        /// </summary>
        public RoomDtoForGetResponses Room { get; set; }

        /// <summary>
        /// Studenci zapisani na dane zajęcia
        /// </summary>
        public ICollection<StudentDtoForFacultyLessonDtos> Students { get; set; }
    }
}
