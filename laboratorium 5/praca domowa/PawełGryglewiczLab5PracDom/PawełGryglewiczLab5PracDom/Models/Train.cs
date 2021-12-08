using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca pociąg
    /// </summary>
    public class Train
    {
        /// <summary>
        /// Klucz główny 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Producent pociągu
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Model pociągu
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Model { get; set; }

        /// <summary>
        /// Typ napędu
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string PowerType { get; set; }

        /// <summary>
        /// Rok produkcji
        /// </summary>
        [Required]
        public int YearOfProduction { get; set; }

        /// <summary>
        /// Liczba wagonów
        /// </summary>
        [Required]
        public int NumberOfCars { get; set; }

        /// <summary>
        /// Maksymalna prędkość pociągu
        /// </summary>
        [Required]
        public int MaxSpeed { get; set; }

        /// <summary>
        /// Waga pociągu
        /// </summary>
        [Required]
        public int Weigth { get; set; }
    }
}
