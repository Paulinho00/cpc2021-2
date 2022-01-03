using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca studenta
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Imię studenta
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko studenta
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Numer PESEL 
        /// </summary>
        [Required]
        public string Pesel { get; set; }

        /// <summary>
        /// Numer indeksu
        /// </summary>
        [Required]
        public int Index { get; set; }

        /// <summary>
        /// Id wydziału, na którym student studiuje
        /// </summary>
        [Required]
        public int FacultyId { get; set; }

        /// <summary>
        /// Nazwa studiowanego kierunku
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Zajęcia na które jest zapisany student
        /// </summary>
        public ICollection<Lesson> Lessons { get; set; }
    }
}
