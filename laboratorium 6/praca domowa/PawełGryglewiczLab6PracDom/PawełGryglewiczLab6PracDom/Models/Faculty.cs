using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca wydział
    /// </summary>
    public class Faculty
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Numer wydziału
        /// </summary>
        [Required]
        [Range(1,20)]
        public int Number { get; set; }

        /// <summary>
        /// Pełna nazwa wydziału
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Lista budynków należących do wydziału
        /// </summary>
        public ICollection<Building> Building { get; set; }

        /// <summary>
        /// Lista prowadzących pracujących na wydziale
        /// </summary>
        public ICollection<Lecturer> Lecturers { get; set; }

        /// <summary>
        /// Lista studentów na wydziale
        /// </summary>
        public ICollection<Student> Student { get; set; }

    }
}
