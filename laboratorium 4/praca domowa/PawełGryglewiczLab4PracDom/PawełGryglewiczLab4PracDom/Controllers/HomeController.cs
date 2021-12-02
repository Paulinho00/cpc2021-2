using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using PawełGryglewiczLab4PracDom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

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
            transfersList.Add(new Transfer("Wypłata", 1800, new DateTime(2021,10,30,12,15,32), "Jan Kowalski","JOB S.A."));
            transfersList.Add(new Transfer("Wygrana w lotto", 500,new DateTime(2021,11,4,21,30,34),"Jan Kowalski","Lotto S.A."));
            transfersList.Add(new Transfer("Opłata za prąd", -300,new DateTime(2021,11,6,8,5,30),"Tauron Energia","Jan Kowalski"));
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
                    //Zapisanie aktualnie zalogowanego użytkownika w sesji
                    HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));
                    //Przekazanie użytkownika do widoku
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
            //Odczyt użytkownika z sesji
            String serialized = HttpContext.Session.GetString("CurrentUser");
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            //Przekazanie użytkownika do widoku
            TempData["CurrentUser"] = user;
            return View();
        }

        public IActionResult TransfersView()
        {
            //Odczyt użytkownika z sesji
            String serialized = HttpContext.Session.GetString("CurrentUser");
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            //Przekazanie listy przelewów użytkownika do widoku
            TempData["Transfers"] = user.TransfersList;
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
