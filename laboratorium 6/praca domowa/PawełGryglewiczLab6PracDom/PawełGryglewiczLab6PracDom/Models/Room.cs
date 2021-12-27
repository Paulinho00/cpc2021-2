using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca pomieszczenie
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Numer sali
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Numer piętra, na którym jest sala
        /// </summary>
        [Required]
        public int FloorNumber { get; set; }

        /// <summary>
        /// Liczba miejsc
        /// </summary>
        [Required]
        public int NumberOfPlaces { get; set; }

        /// <summary>
        /// Id budynku, w którym znajduje się sala
        /// </summary>
        [Required]
        public int BuildingId { get; set; }

        /// <summary>
        /// Obiekt budynku, w którym znajduje się sala
        /// </summary>
        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        /// <summary>
        /// Lista zajęć, które odbywają się w sali
        /// </summary>
        public ICollection<Lesson> Lessons { get; set; }
    }
}
