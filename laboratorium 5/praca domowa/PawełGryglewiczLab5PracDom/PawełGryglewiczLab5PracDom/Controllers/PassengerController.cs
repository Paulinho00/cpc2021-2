using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab5PracDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Controllers
{
    /// <summary>
    /// Kontroler do klasy Passenger.cs
    /// </summary>
    public class PassengerController : Controller
    {
        /// <summary>
        /// Zmienna przechowująca referencję do modelu bazy danych
        /// </summary>
        private readonly DatabaseContext _context;

        public PassengerController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint żadania GET do widoku wyświetlającego wszystkich pasażerów
        /// </summary>
        /// <returns></returns>
        public IActionResult ListOfPassengers()
        {
            //Pobranie listy wszystkich połączeń
            List<RailwayConnection> railwayConnections = _context.RailwayConnections
                                        .Include(railwayConnection => railwayConnection.Destination)
                                        .Include(railwayConnection => railwayConnection.PlaceOfDeparture)
                                        .ToList();

            //Pobranie wszystkich pasażerów wraz z zagnieżdżonymi obiektami z innych tabel
            List<Passenger> passengers = _context.Passengers
                                .Include(passenger => passenger.RailwayConnection)
                                .ThenInclude(railwayConnection => railwayConnection.Destination)
                                .Include(passenger => passenger.RailwayConnection)
                                .ThenInclude(railwayConnection => railwayConnection.PlaceOfDeparture)
                                .OrderBy(passenger => passenger.LastName)
                                .ToList();

            //Zapisanie tytułu przycisku rozwijanego menu w widoku
            ViewBag.DropdownTitle = "Wszyscy";

            RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel = new RailwayConnectionPassengerViewModel(passengers, railwayConnections);
            return View(railwayConnectionPassengerViewModel);
        }

        /// <summary>
        /// Endpoint żadania GET do widoku wyświetlającego pasażerów przypisanych do wybranej trasy
        /// </summary>
        /// <param name="id">Id wybranej trasy</param>
        /// <returns></returns>
        public IActionResult PassengersByRailwayConnection(int id)
        {
            //Pobranie listy wszystkich połączeń
            List<RailwayConnection> railwayConnections = _context.RailwayConnections
                                        .Include(railwayConnection => railwayConnection.Destination)
                                        .Include(railwayConnection => railwayConnection.PlaceOfDeparture)
                                        .ToList();
            //Pobranie pasażerów przypisanych do określonej trasy wraz z zagnieżdżonymi obiektami z innych tabel
            List<Passenger> passengers = _context.Passengers
                                .Include(passenger => passenger.RailwayConnection)
                                .ThenInclude(railwayConnection => railwayConnection.Destination)
                                .Include(passenger => passenger.RailwayConnection)
                                .ThenInclude(railwayConnection => railwayConnection.PlaceOfDeparture)
                                .OrderBy(passenger => passenger.LastName)
                                .Where(passenger => passenger.RailwayConnectionId == id)
                                .ToList();
            //Zapisanie tytułu przycisku rozwijanego menu w widoku
            RailwayConnection chosenRailwayConnection = _context.RailwayConnections.SingleOrDefault(railwayConnection => railwayConnection.Id == id);
            ViewBag.DropdownTitle = chosenRailwayConnection.PlaceOfDeparture.Town + "-" + chosenRailwayConnection.Destination.Town;

            RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel = new RailwayConnectionPassengerViewModel(passengers, railwayConnections);
            return View("ListOfPassengers",railwayConnectionPassengerViewModel);
        }
    }
}
