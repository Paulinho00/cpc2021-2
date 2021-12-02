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
        //Adres email
        public string Email { get; set; }
        //Hasło
        public string Password { get; set; }

        public UserData()
        {

        }

        public UserData(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
