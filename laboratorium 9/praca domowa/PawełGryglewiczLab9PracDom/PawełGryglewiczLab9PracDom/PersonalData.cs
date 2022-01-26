using System;

namespace PawełGryglewiczLab9PracDom
{
    /// <summary>
    /// Klasa przechowująca dane osobowe i sprawdzające ich poprawność
    /// </summary>
    public class PersonalData
    {
        /// <summary>
        /// Data urodzenia
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Płeć osoby
        /// </summary>
        public bool isPersonMale { get; set; }

        /// <summary>
        /// Zmienna przechowująca informację czy osoba ma stałe miejsce zamieszkania
        /// </summary>
        public bool HasPernamentPlaceOfResidence { get; set; }

        /// <summary>
        /// Numer PESEL
        /// </summary>
        public string IdNumber { get; set; }

        public PersonalData(DateTime birthDate, bool isPersonMale, bool hasPernamentPlaceOfResidence, string idNumber)
        {
            BirthDate = birthDate;
            this.isPersonMale = isPersonMale;
            HasPernamentPlaceOfResidence = hasPernamentPlaceOfResidence;
            IdNumber = idNumber;
        }

        /// <summary>
        /// Metoda sprawdzająca poprawność numeru PESEL
        /// </summary>
        /// <returns>wartość true jeśli numer PESEL jest poprawny</returns>
        public bool IdNumberValidate()
        {
            //Sprawdzenie czy długość PESEL jest poprawna
            if (IdNumber.Length != 11) return false;

            return true;
        }
    }
}
