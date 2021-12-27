using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca budynek
    /// </summary>
    public class Building
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Kategoria budynku
        /// </summary>
        [Required]
        public char Category { get; set; }

        /// <summary>
        /// Numer budynku
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Rok budowy
        /// </summary>
        [Required]
        [Range(1900, 2021)]
        public int YearOfBuild { get; set; }

        /// <summary>
        /// Wydział do którego należy budynek
        /// </summary>
        [Required]
        public Faculty FacultyId { get; set; }

        /// <summary>
        /// Liczba pięter
        /// </summary>
        [Required]
        [Range(1,20)]
        public int NumberOfFloors { get; set; }

        /// <summary>
        /// Sale, które znajdują się w budynku
        /// </summary>
        public ICollection<Room> Rooms { get; set; }


    }
}
