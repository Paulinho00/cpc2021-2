using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab4PracDom.Models
{
    /// <summary>
    /// Klasa reprezentująca przelew
    /// </summary>
    public class Transfer
    {
        /// <summary>
        /// Tytuł przelewu
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Kwota przelewu
        /// </summary>
        public double Sum { get; set; }
        /// <summary>
        /// Data przelewu
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Nr konta odbiorcy
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Nadawca przelewu
        /// </summary>
        public string Sender { get; set; }
        public Transfer(string title, double sum, string date, string recipient, string sender)
        {
            Title = title;
            Sum = sum;
            Date = date;
            Recipient = recipient;
            Sender = sender;
        }

    }
}
