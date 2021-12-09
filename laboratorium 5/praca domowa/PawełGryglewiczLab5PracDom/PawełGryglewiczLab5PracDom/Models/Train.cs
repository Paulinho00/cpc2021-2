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
        [Display(Name ="Producent")]
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
        [Display(Name ="Rodzaj napędu")]
        public string PowerType { get; set; }

        /// <summary>
        /// Rok produkcji
        /// </summary>
        [Required]
        [Display(Name ="Rok produkcji")]
        public int YearOfProduction { get; set; }

        /// <summary>
        /// Liczba wagonów
        /// </summary>
        [Required]
        [Display(Name ="Ilość wagonów")]
        public int NumberOfCars { get; set; }

        /// <summary>
        /// Maksymalna prędkość pociągu
        /// </summary>
        [Required]
        [Display(Name ="Maksymalna prędkość")]
        public int MaxSpeed { get; set; }

        /// <summary>
        /// Waga pociągu
        /// </summary>
        [Required]
        [Display(Name ="Masa")]
        public int Weigth { get; set; }
    }
}
