using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [MaxLength(25)]
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

        /// <summary>
        /// Połączenia w których stacja jest początkiem trasy
        /// </summary>
        [InverseProperty("PlaceOfDeparture")]
        public ICollection<RailwayConnection> DeparturePlaceInConnection { get; set; }

        /// <summary>
        /// Połączenia w których stacja jest końcem trasy
        /// </summary>
        [InverseProperty("Destination")]
        public ICollection<RailwayConnection> DestinationInConnection { get; set; }
    }
}
