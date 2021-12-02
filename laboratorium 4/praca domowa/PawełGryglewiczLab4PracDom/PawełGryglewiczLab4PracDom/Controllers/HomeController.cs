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
            allUsers = new List<UserData>();
            allUsers.Add(new UserData("jan.kowalski@gmail.com", "haslo123"));
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
                    TempData["CurrentUser"] = userData;
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
