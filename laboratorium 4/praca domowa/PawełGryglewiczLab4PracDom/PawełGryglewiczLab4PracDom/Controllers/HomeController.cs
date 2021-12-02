using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PawełGryglewiczLab4PracDom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab4PracDom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Lista zarejestrowanych użytkowników
        /// </summary>
        private List<UserData> allUsers;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //Hardcodowanie przykładowego użytkownika
            List<Transfer> transfersList = new List<Transfer>();
            transfersList.Add(new Transfer("Wypłata", 1800, "30-10-2021", "Jan Kowalski","JOB S.A."));
            transfersList.Add(new Transfer("Wygrana w lotto", 500,"04-11-2021","Jan Kowalski","Lotto S.A."));
            transfersList.Add(new Transfer("Opłata za prąd", -300, "06-11-2021","Tauron Energia","Jan Kowalski"));
            allUsers = new List<UserData>();
            allUsers.Add(new UserData("jan.kowalski@gmail.com", "haslo123", "Jan", "Kowalski", -2000.39, "98122431817", "53 1020 5356 3272 8458 2581 9498",transfersList)) ;
        }

        /// <summary>
        /// Endpoint żadania GET strony logowania
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Endpoint żądania POST strony logowania
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(UserData userData)
        {
            foreach (var user in allUsers)
            {
                if (user.Email.Equals(userData.Email) && user.Password.Equals(userData.Password)) 
                {
                    //Zapisanie aktualnie zalogowanego użytkownika
                    TempData["CurrentUser"] = user;
                    return View("MainPage");
                }
            }
            //Przekazanie informacji o błędnych danych logowania
            ViewBag.IsCorrect = false;
            return View("Index");
        }

 
        /// <summary>
        /// Endpoint głównej strony konta
        /// </summary>
        /// <returns></returns>
        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
