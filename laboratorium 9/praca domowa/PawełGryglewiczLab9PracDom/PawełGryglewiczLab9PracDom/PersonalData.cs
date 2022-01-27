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

            int dayOfBirth = BirthDate.Day;
            int monthOfBirth = BirthDate.Month;
            int yearOfBirth = BirthDate.Year;
            //Sprawdzenie czy jest to numer D
            if (HasPernamentPlaceOfResidence)
            {
                //Sprawdzenie zgodności dnia miesiąca daty urodzin z numerem PESEL
                if (Int32.Parse(IdNumber.Substring(0, 2)) != dayOfBirth) return false;
            }
            else
            {
                //Sprawdzenie zgodności dnia miesiąca daty urodzin z numerem D
                if (Int32.Parse(IdNumber.Substring(0, 2))-40 != dayOfBirth) return false;
            }
            //Sprawdzenie zgodności miesiąca urodzin z numerem PESEL
            if (Int32.Parse(IdNumber.Substring(2, 2)) != monthOfBirth) return false;
            //Sprawdzenie zgodności roku urodzenia z numerem PESEL
            if (Int32.Parse(IdNumber.Substring(4, 2)) != yearOfBirth % 100) return false;


            //Sprawdzenie zgodności płci z numerem PESEL
            int individualNumber = Int32.Parse(IdNumber.Substring(6, 3));
            if (isPersonMale && individualNumber % 2 == 0) return false;
            if (!isPersonMale && individualNumber % 2 != 0) return false;

            //Sprawdzenie zgodności roku urodzenia z indywidualnym numerem
            int birthYear = BirthDate.Year;
            if ((birthYear >= 1854 && birthYear <= 1899) && (individualNumber < 500 || individualNumber > 749)) return false;
            if (birthYear >= 1900 && birthYear <= 1999 && individualNumber > 499) return false;
            if (birthYear >= 2000 && birthYear <= 2039 && individualNumber < 500) return false;


            return true;
        }
    }
}
