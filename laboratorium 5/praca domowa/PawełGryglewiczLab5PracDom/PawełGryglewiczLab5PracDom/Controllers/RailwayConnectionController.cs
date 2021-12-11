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
    /// Kontroler dla klasy RailwayConnection.cs
    /// </summary>
    public class RailwayConnectionController : Controller
    {
        /// <summary>
        /// Zmienna przechowująca referencję do modelu bazy danych
        /// </summary>
        private readonly DatabaseContext _context;

        public RailwayConnectionController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint żadania GET do widoku wyświetlającego wszystkie połączenia
        /// </summary>
        /// <returns></returns>
        public IActionResult ListOfConnections()
        {
            //Pobranie wszystkich połączeń wraz z zagnieżdżonymi obiektami z innych tabel
            var railwayConnections = _context.RailwayConnections
                                        .Include(railwayConnection => railwayConnection.Train)
                                        .Include(railwayConnection => railwayConnection.Destination)
                                        .Include(railwayConnection => railwayConnection.PlaceOfDeparture)
                                        .OrderBy(railwayConnection => railwayConnection.TimeOfDeparture)
                                        .ToList();

            return View(railwayConnections);
        }
    }
}
