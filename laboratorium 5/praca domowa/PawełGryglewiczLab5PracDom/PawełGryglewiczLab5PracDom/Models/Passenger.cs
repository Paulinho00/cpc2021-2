using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca pojedynczego pasażera
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Imię pasażera
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko pasażera
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Wiek pasażera
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Adres email pasażera
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Typ biletu pasażera
        /// </summary>
        [Required]
        public string TicketType { get; set; }

        /// <summary>
        /// Id połączenia kolejowego pasażera
        /// </summary>
        [Required]
        public int RailwayConnectionId { get; set; }

        /// <summary>
        /// Obiekt połączenia kolejowego pasażera
        /// </summary>
        [ForeignKey("RailwayConnectionId")]
        public RailwayConnection RailwayConnection { get; set; }

    }
}
