using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto
{
    /// <summary>
    /// Klasa odpowiadająca DTO klasy Room dla zapytań Post i Put
    /// </summary>
    public class RoomDtoForPostPutResponses
    {
        /// <summary>
        /// Numer sali
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Numer piętra, na którym jest sala
        /// </summary>
        public int FloorNumber { get; set; }

        /// <summary>
        /// Liczba miejsc
        /// </summary>
        public int NumberOfPlaces { get; set; }

        /// <summary>
        /// Id budynku, w którym znajduje się sala
        /// </summary>
        public int BuildingId { get; set; }
    }
}
