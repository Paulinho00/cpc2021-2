using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Models
{
    /// <summary>
    /// ViewModel zawierający modele pasażera i połączenia kolejowego
    /// </summary>
    public class RailwayConnectionPassengerViewModel
    {
        /// <summary>
        /// Lista pasażerów 
        /// </summary>
        public List<Passenger> Passengers { get; set; }
        /// <summary>
        /// Lista połączeń kolejowych
        /// </summary>
        public List<RailwayConnection> RailwayConnections { get; set; }

        public RailwayConnectionPassengerViewModel(List<Passenger> passengers, List<RailwayConnection> railwayConnections)
        {
            Passengers = passengers;
            RailwayConnections = railwayConnections;
        }


    }
}
