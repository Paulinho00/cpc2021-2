using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca prowadzącego zajęcia
    /// </summary>
    public class Lecturer
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Imię prowadzącego
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko prowadzącego
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Numer PESEL
        /// </summary>
        [Required]
        public int Pesel { get; set; }

        /// <summary>
        /// Stopień naukowy
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Degree { get; set; }

        /// <summary>
        /// Id wydziału, na którym pracuje prowadzący
        /// </summary>
        [Required]
        public int FacultyId { get; set; }

        /// <summary>
        /// Obiekt wydziału, na którym pracuje prowadzący
        /// </summary>
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

    }
}
