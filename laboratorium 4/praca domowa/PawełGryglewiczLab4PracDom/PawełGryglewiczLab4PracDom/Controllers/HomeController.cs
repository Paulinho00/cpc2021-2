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
            transfersList.Add(new Transfer("Wypłata", 1800, new DateTime(2021,10,30,12,15,32).ToString(), "Jan Kowalski","JOB S.A."));
            transfersList.Add(new Transfer("Wygrana w lotto", 500,new DateTime(2021,11,4,21,30,34).ToString(),"Jan Kowalski","Lotto S.A."));
            transfersList.Add(new Transfer("Opłata za prąd", -300,new DateTime(2021,11,6,8,5,30).ToString(),"Tauron Energia","Jan Kowalski"));
            allUsers = new List<UserData>();
            allUsers.Add(new UserData("jan.kowalski@gmail.com", "haslo123", "Jan", "Kowalski", 2000, "98122431817", "53 1020 5356 3272 8458 2581 9498",transfersList)) ;
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
            string serialized = HttpContext.Session.GetString("CurrentUser") as string;
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            //Przekazanie użytkownika do widoku
            TempData["CurrentUser"] = user;
            return View();
        }


        /// <summary>
        /// Endpoint strony wyświetlającej wszystkie transakcje
        /// </summary>
        /// <returns></returns>
        public IActionResult TransfersView()
        {
            //Odczyt użytkownika z sesji
            string serialized = HttpContext.Session.GetString("CurrentUser") as string;
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            //Przekazanie listy przelewów użytkownika do widoku
            TempData["Transfers"] = user.TransfersList;
            return View();
        }

        /// <summary>
        /// Endpoint żądania GET strony wysyłającej przelew
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TransferForm()
        {
            //Odczyt użytkownika z sesji
            string serialized = HttpContext.Session.GetString("CurrentUser") as string;
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            Transfer newTransfer = new Transfer();
            //Przekazanie aktualnej daty i godziny do widoku
            newTransfer.Date = DateTime.Now.ToString();
            //Obliczenie i przekazanie do widoku maksymalnej wartości przelewu
            if (user.Balance + 2000 < 0)
            {
                TempData["MaxValue"] = 0;
            }
            else
            {
                TempData["MaxValue"] = user.Balance + 2000;
            }
            //Przekazanie do widoku imienia i nazwiska nadawcy przelewu
            newTransfer.Sender = user.FirstName + " " + user.Surname;
            return View(newTransfer);
        }

        /// <summary>
        /// Endpoint żądania POST strony wysyłającej przelew
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TransferForm(Transfer transfer)
        {
            //Odczyt użytkownika z sesji
            string serialized = HttpContext.Session.GetString("CurrentUser") as string;
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            //Sprawdzenie czy wszystkie pola są wypełnione
            if (transfer.Title != null && transfer.Recipient != null && transfer.Sum != 0)
            {
                //Odjęcie kwoty przelewu od konta
                user.Balance -= transfer.Sum;
                transfer.Sum *= -1;
                //Dodanie nowego przelewu do listy
                user.TransfersList.Add(transfer);
                //Zapisanie zaktualizowanego obiektu użytkownika w sesji
                HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));
                //Przekazanie użytkownika do widoku
                TempData["CurrentUser"] = user;
                return View("MainPage");
            }
            ViewBag.IsCorrect = false;
            Transfer newTransfer = new Transfer();
            //Przekazanie aktualnej daty i godziny do widoku
            newTransfer.Date = DateTime.Now.ToString();
            //Obliczenie i przekazanie do widoku maksymalnej wartości przelewu
            if (user.Balance + 2000 < 0)
            {
                TempData["MaxValue"] = 0;
            }
            else
            {
                TempData["MaxValue"] = user.Balance + 2000;
            }
            //Przekazanie do widoku imienia i nazwiska nadawcy przelewu
            newTransfer.Sender = user.FirstName + " " + user.Surname;
            return View("TransferForm");
        }

        /// <summary>
        /// Endpoint żądania GET strony edytującej dane użytkownika
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditUserData()
        {
            //Odczyt użytkownika z sesji
            string serialized = HttpContext.Session.GetString("CurrentUser") as string;
            UserData user = JsonConvert.DeserializeObject<UserData>(serialized);
            return View(user);
        }

        /// <summary>
        /// Endpoint żadania POST strony edytującej dane użytkownika
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditUserData(UserData user)
        {
            //Odczyt użytkownika z sesji
            string serialized = HttpContext.Session.GetString("CurrentUser") as string;
            UserData oldUser = JsonConvert.DeserializeObject<UserData>(serialized);
            //Sprawdzenie czy wszystkie pola zostały poprawnie wypełnione
            if (user.FirstName == null || user.Surname == null || user.Email == null)
            {
                //Przekazanie informacji o błędnych danych
                ViewBag.IsCorrect = false;
                return View(oldUser);

            }

            //Przekazanie listy przelewów do zmienionego obiektu użytkownika
            user.TransfersList = oldUser.TransfersList;
            //Pętla zmieniająca imię i nazwisko we wszystkich przelewach nadanych przez użytkownika
            foreach(var transfer in user.TransfersList)
            {
                string sender = oldUser.FirstName + " " + oldUser.Surname;
                if (transfer.Sender.Equals(sender))
                {
                    transfer.Sender = user.FirstName + " " + user.Surname;
                }

            }
            //Zapisanie zmienionego użytkownika w sesji
            HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));
            //Przekazanie użytkownika do widoku
            TempData["CurrentUser"] = user;
            return View("MainPage");
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
