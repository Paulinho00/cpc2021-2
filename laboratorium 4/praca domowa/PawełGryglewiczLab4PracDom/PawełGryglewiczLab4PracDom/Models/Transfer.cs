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
        public float Sum { get; set; }
        /// <summary>
        /// Data przelewu
        /// </summary>
        public string Date { get; set; }

        public Transfer(string title, float sum, string date)
        {
            Title = title;
            Sum = sum;
            Date = date;
        }

    }
}
