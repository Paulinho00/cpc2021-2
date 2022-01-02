using PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto
{
    /// <summary>
    /// Klasa odpowiadająca DTO klasy Room dla zapytań Get
    /// </summary>
    public class RoomDtoForGetResponses
    {
        /// <summary>
        /// Klucz główny
        /// </summary>
        public int Id { get; set; }

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
        /// Obiekt budynku, w którym znajduje się sala
        /// </summary>
        public BuildingDtoForRoomDto Building { get; set; }
    }
}
