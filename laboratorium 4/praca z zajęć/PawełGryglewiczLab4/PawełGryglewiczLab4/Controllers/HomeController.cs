using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PawełGryglewiczLab4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Lista samochodów
        List<CarViewModel> allCars;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            allCars = new List<CarViewModel>();
            allCars.Add(new CarViewModel("Focus", "Ford", 72000, "~/focus.png"));
            allCars.Add(new CarViewModel("Golf", "Volkswagen", 80000, "~/golf.png"));
            allCars.Add(new CarViewModel("Civic", "Honda", 82000, "~/civic.png"));
            allCars.Add(new CarViewModel("Megane", "Renault", 68000, "~/megane.png"));

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InterestingLinks()
        {
            return View();
        }

        //Zwraca widok wszystkich samochodów
        public IActionResult GetAllCars()
        {
            return View(allCars);
        }

        //Zwraca widok dostępnych modeli
        public IActionResult GetListOfModels()
        {
            List<string> allModels = new List<string>();

            foreach (CarViewModel car in allCars)
            {
                allModels.Add(car.Model);
            }

            return View(allModels);
        }

        public IActionResult GetCarByModel(string model)
        {
            CarViewModel car = allCars.SingleOrDefault(a => a.Model == model);
            return View(car);
        }

        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactForm(ContactFormViewModel userData)
        {
            string welcomeText = "Witaj" + userData.FirstName + " " + userData.LastName;
            ViewBag.WelcomeText = welcomeText;
            return View("ContactFormGreetings");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
