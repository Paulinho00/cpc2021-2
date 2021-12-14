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

            //Zapisanie tytułu przycisku rozwijanego menu i id wybranego połączenia w widoku
            ViewBag.DropdownTitle = "Wszyscy";
            ViewBag.ChosenRailwayConnectionId = 0;

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
            //Zapisanie tytułu przycisku rozwijanego menu i id wybranego połączenia w widoku
            RailwayConnection chosenRailwayConnection = _context.RailwayConnections.SingleOrDefault(railwayConnection => railwayConnection.Id == id);
            ViewBag.DropdownTitle = chosenRailwayConnection.PlaceOfDeparture.Town + "-" + chosenRailwayConnection.Destination.Town;
            ViewBag.ChosenRailwayConnectionId = id;

            RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel = new RailwayConnectionPassengerViewModel(passengers, railwayConnections);
            return View("ListOfPassengers", railwayConnectionPassengerViewModel);
        }

        /// <summary>
        /// Endpoint żadania DELETE do wybranego pasażera
        /// </summary>
        /// <param name="passengerId">obiekt wybranego pasażera</param>
        /// <param name="railwayConnectionId">id wybranego połączenia kolejowego według którego są posortowani pasażerowie</param>
        /// <returns></returns>
        public IActionResult DeletePassenger(int passengerId, int railwayConnectionId)
        {
            //Odczyt pasażera z bazy danych
            Passenger passenger = _context.Passengers
                .FirstOrDefault(p => p.Id.Equals(passengerId));

            //Usunięcie pasażera z bazy danych
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();

            //Zwrócenie wyglądu który był widoczny w chwili usuwania pasażera
            if (railwayConnectionId == 0)
                return this.RedirectToAction("ListOfPassengers", "Passenger");
            else
                return this.RedirectToAction("PassengersByRailwayConnection", "Passenger", new { id = railwayConnectionId });
        }

        /// <summary>
        /// Endpoint żadania GET do widoku formularza rezerwacji biletu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreatePassengerForm()
        {
            //Pobranie listy wszystkich połączeń
            List<RailwayConnection> railwayConnections = _context.RailwayConnections
                                        .Include(railwayConnection => railwayConnection.Destination)
                                        .Include(railwayConnection => railwayConnection.PlaceOfDeparture)
                                        .ToList();
            RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel = new RailwayConnectionPassengerViewModel(railwayConnections);

            //Sprawdzenie czy trzeba wysłać komunikat błędu
            try
            {
                if ((bool)TempData["IsCorrect"] == false)
                    ViewBag.IsCorrect = false;
            }
            catch (NullReferenceException e) { };

            return View(railwayConnectionPassengerViewModel);
        }

        /// <summary>
        /// Endpoint żadania POST widoku formularza rezerwacji biletu
        /// </summary>
        /// <param name="railwayConnectionPassengerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreatePassengerForm(RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel)
        {
            //Odczyt nowego pasażera z obiektu
            Passenger createdPassenger = railwayConnectionPassengerViewModel.Passengers[0];

            //Sprawdzenie czy obiekt posiada wszystkie dane
            try
            {
                createdPassenger.FirstName.Equals(null);
                createdPassenger.LastName.Equals(null);
                createdPassenger.Age.Equals(null);
                createdPassenger.EmailAddress.Equals(null);
                createdPassenger.TicketType.Equals(null);
                if (createdPassenger.RailwayConnectionId.Equals(0))
                {
                    TempData["IsCorrect"] = false;
                    return RedirectToAction("CreatePassengerForm");
                }
            }
            catch (NullReferenceException e)
            {
                //Wysłanie informacji do następnego żadania o błędnych danych
                TempData["IsCorrect"] = false;
                return RedirectToAction("CreatePassengerForm");
            }

            //Zapis obiektu do bazy danych
            _context.Passengers.Add(createdPassenger);
            _context.SaveChanges();


            return RedirectToAction("ListOfPassengers");
        }


        /// <summary>
        /// Endpoint żadania GET do widoku edycji danych pasażera
        /// </summary>
        /// <param name="passengerId">ID wybranego pasażera</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditPassengerForm(int passengerId)
        {
            //Pobranie obiektu wybranego pasażera z bazy danych
            Passenger passenger = _context.Passengers.FirstOrDefault(p => p.Id.Equals(passengerId));
            List<Passenger> passengers = new List<Passenger>() { passenger };

            //Pobranie listy wszystkich połączeń
            List<RailwayConnection> railwayConnections = _context.RailwayConnections
                                        .Include(railwayConnection => railwayConnection.Destination)
                                        .Include(railwayConnection => railwayConnection.PlaceOfDeparture)
                                        .ToList();

            //Sprawdzenie czy trzeba wysłać komunikat błędu
            try
            {
                if ((bool)TempData["IsCorrect"] == false)
                    ViewBag.IsCorrect = false;
            }
            catch (NullReferenceException e) { };

            RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel = new RailwayConnectionPassengerViewModel(passengers, railwayConnections);
            ViewBag.Id = passengerId;
            return View(railwayConnectionPassengerViewModel);
        }

        /// <summary>
        /// Endpoint POST do widoku edycji danych pasażera
        /// </summary>
        /// <param name="railwayConnectionPassengerViewModel">obiekt ze zmodyfikowanym obiektem pasażera</param>
        /// <param name="passengerId">Id modyfikowanego pasażera</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditPassengerForm(RailwayConnectionPassengerViewModel railwayConnectionPassengerViewModel, int passengerId)
        {
            //Odczyt zmodyfikowanego obiektu pasażera
            Passenger modifiedPassenger = railwayConnectionPassengerViewModel.Passengers[0];

            //Sprawdzenie czy obiekt posiada wszystkie dane
            try
            {
                modifiedPassenger.FirstName.Equals(null);
                modifiedPassenger.LastName.Equals(null);
                modifiedPassenger.Age.Equals(null);
                modifiedPassenger.EmailAddress.Equals(null);
                modifiedPassenger.TicketType.Equals(null);
                if (modifiedPassenger.RailwayConnectionId.Equals(0))
                {
                    TempData["IsCorrect"] = false;
                    return RedirectToAction("EditPassengerForm");
                }
            }
            catch (NullReferenceException e)
            {
                //Wysłanie informacji do następnego żadania o błędnych danych
                TempData["IsCorrect"] = false;
                return RedirectToAction("EditPassengerForm");
            }

            //Odczyt edytowanego pasażera z bazy danych
            Passenger entity = _context.Passengers.Find(passengerId);
            
            //Uzupełnienie zmodyfikowanego pasażera o obiekt połączenia kolejowego i odpowiednie id
            modifiedPassenger.RailwayConnection = _context.RailwayConnections.SingleOrDefault(connection => connection.Id.Equals(modifiedPassenger.RailwayConnectionId));
            modifiedPassenger.Id = passengerId;

            //Zapisanie zmian danych pasażera w bazie danych
            _context.Entry(entity).CurrentValues.SetValues(modifiedPassenger);
            _context.SaveChanges();

            return RedirectToAction("ListOfPassengers");

        }


    }

}

