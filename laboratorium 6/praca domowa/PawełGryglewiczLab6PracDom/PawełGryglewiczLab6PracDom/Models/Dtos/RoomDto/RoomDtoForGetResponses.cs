using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto
{
    public class RoomDtoForGetResponses
    {
        /// <summary>
        /// Numer sali
        /// </summary>
        public int Number { get; set; }


        /// <summary>
        /// Numer piętra, na którym jest sala
        /// </summary>
        public int FloorNumber { get; set; }

        public int NumberOfPlaces { get; set; }

        /// <summary>
        /// Obiekt budynku, w którym znajduje się sala
        /// </summary>
        public Building Building { get; set; }
    }
}
