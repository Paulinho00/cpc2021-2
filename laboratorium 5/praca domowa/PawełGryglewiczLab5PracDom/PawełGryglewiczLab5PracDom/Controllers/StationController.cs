using Microsoft.AspNetCore.Mvc;
using PawełGryglewiczLab5PracDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Controllers
{
    /// <summary>
    /// Kontroler dla klasy Station.cs
    /// </summary>
    public class StationController : Controller
    {
        /// <summary>
        /// Zmienna przechowująca referencję do modelu bazy danych
        /// </summary>
        private readonly DatabaseContext _context;

        public StationController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint żadania GET do widoku wyświetlającego wszystkie pociągi
        /// </summary>
        /// <returns></returns>
        public IActionResult ListOfStations()
        {
            return View(_context.Stations.ToList());
        }
    }
}
