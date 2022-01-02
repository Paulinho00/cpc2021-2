
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto
{
    /// <summary>
    /// Klasa reprezentująca dto dla klasy Room do obiektów Dto klasy Building
    /// </summary>
    public class RoomDtoForBuildingDto
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
    }
}
