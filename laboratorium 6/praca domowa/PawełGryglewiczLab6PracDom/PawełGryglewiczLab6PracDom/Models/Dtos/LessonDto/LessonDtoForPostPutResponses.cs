using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto
{
    /// <summary>
    /// Klasa reprezentująca dto klasy Lesson do zapytań POST i PUT
    /// </summary>
    public class LessonDtoForPostPutResponses
    {
        /// <summary>
        /// Data zajęć
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Przedmiot, którego dotyczą zajęcia
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Id prowadzącego zajęcia
        /// </summary>
        public int LecturerId { get; set; }

        /// <summary>
        /// Id pomieszczenia, w którym odbywają się zajęcia 
        /// </summary>
        public int? RoomId { get; set; }
    }
}
