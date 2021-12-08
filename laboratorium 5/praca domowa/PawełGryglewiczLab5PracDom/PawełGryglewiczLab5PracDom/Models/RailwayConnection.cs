using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca połączenie kolejowe
    /// </summary>
    public class RailwayConnection
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Czas odjazdu
        /// </summary>
        [Required]
        public DateTime TimeOfDeparture { get; set; }

        /// <summary>
        /// Id stacji początkowej
        /// </summary>
        public int PlaceOfDepartureId { get; set; }

        /// <summary>
        /// Czas przyjazdu
        /// </summary>
        [Required]
        public  DateTime TimeOfArrival { get; set; }

        /// <summary>
        /// Id stacji końcowej
        /// </summary>
        public int? DestinationId { get; set;}

        /// <summary>
        /// Id pociągu
        /// </summary>
        [Required]
        public int TrainId { get; set; }

        /// <summary>
        /// Obiekt stacji początkowej
        /// </summary>
        [ForeignKey("PlaceOfDepartureId")]
        public Station PlaceOfDeparture { get; set; }

        /// <summary>
        /// Obiekt stacji końcowej
        /// </summary>
        [ForeignKey("DestinationId")]
        public Station Destination { get; set; }

        /// <summary>
        /// Obiekt pociągu
        /// </summary>
        [ForeignKey("TrainId")]
        public Train Train { get; set; }

        /// <summary>
        /// Pasażerowie którzy kupili bilet na dane połączenie
        /// </summary>
        public ICollection<Passenger> Passerngers { get; set; }

    }
}
