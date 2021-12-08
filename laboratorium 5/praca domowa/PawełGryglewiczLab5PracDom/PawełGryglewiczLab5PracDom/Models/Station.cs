using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca stację kolejową
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Id stacji
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Miejscowość stacji
        /// </summary>
        [MaxLength(25)][Required]
        public string Town { get; set; }

        /// <summary>
        /// Liczba peronów na stacji
        /// </summary>
        [Required]
        public int PlatformsNumber { get; set; }

        /// <summary>
        /// Rok otwarcia stacji
        /// </summary>
        [Required]
        public int YearOfFound { get; set; }

        /// <summary>
        /// Zmienna przechowująca informację czy stacja ma kasy biletowe
        /// </summary>
        [Required]
        public bool HasTicketOffice { get; set; }
    }
}
