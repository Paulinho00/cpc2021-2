using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab4PracDom.Models
{
    /// <summary>
    /// Klasa przechowująca dane logowania
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Adres email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Hasło
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Imię
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Nazwisko
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Saldo konta
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// Nr PESEL
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// Nr konta
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Lista przelewów
        /// </summary>
        public List<Transfer> TransfersList { get; set; }

        public UserData()
        {

        }

        public UserData(string email, string password, string firstName, string surname, int balance, string idNumber, string accountNumber, List<Transfer> transfersList)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            Surname = surname;
            Balance = balance;
            IdNumber = idNumber;
            AccountNumber = accountNumber;
            TransfersList = transfersList;
        }
    }
}
