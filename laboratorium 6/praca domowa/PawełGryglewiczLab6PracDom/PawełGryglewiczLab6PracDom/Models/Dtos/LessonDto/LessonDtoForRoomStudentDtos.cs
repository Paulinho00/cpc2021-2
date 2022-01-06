using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto
{
    /// <summary>
    /// Klasa reprezentująca dto klasy Lesson dla dto klasy Room
    /// </summary>
    public class LessonDtoForRoomStudentDtos
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
    }
}
