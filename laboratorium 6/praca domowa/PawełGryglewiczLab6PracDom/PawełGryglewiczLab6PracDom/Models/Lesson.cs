using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca pojedyncze zajęcia z danego przedmiotu
    /// </summary>
    public class Lesson
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data zajęć
        /// </summary>
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Przedmiot, którego dotyczą zajęcia
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Id prowadzącego zajęcia
        /// </summary>
        [Required]
        public int LecturerId { get; set; }

        /// <summary>
        /// Id pomieszczenia, w którym odbywają się zajęcia 
        /// </summary>
        public int? RoomId { get; set; }

        /// <summary>
        /// Obiekt prowadzącego zajęcia
        /// </summary>
        [ForeignKey("LecturerId")]
        public Lecturer Lecturer { get; set; }

        /// <summary>
        /// Obiekt pomieszczenia, w którym odbywają się zajęcia
        /// </summary>
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        /// <summary>
        /// Studenci zapisani na dane zajęcia
        /// </summary>
        public ICollection<Student> Students { get; set; }
    }
}
