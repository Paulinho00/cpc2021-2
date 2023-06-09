﻿using System;
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
        [Display(Name ="Imię")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko pasażera
        /// </summary>
        [MaxLength(50)]
        [Required]
        [Display(Name ="Nazwisko")]
        public string LastName { get; set; }

        /// <summary>
        /// Wiek pasażera
        /// </summary>
        [Required]
        [Display(Name ="Wiek")]
        public int Age { get; set; }

        /// <summary>
        /// Adres email pasażera
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name ="Email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Typ biletu pasażera
        /// </summary>
        [Required]
        [Display(Name ="Rodzaj biletu")]
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
        [Display(Name ="Trasa")]
        public RailwayConnection RailwayConnection { get; set; }

    }
}
