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

            //Pobranie dwóch ostatnich cyfr PESEL
            int firstControlDigit = Int32.Parse(IdNumber.Substring(9,1));
            int secondControlDigit = Int32.Parse(IdNumber.Substring(10, 1));

            //Mnożniki do obliczania dwóch ostatnich cyfr
            int[] multipliersForFirstControlDigit = { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
            int[] multipliersForSecondControlDigit = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };


            //Obliczanie pierwszej cyfry kontrolnej
            int sum = 0;
            for(int i = 0; i < 9; i++)
            {
                sum += Int32.Parse(IdNumber.Substring(i, 1)) * multipliersForFirstControlDigit[i]; 
            }
            int calculatedFirstControlDigit = 11 - (sum % 11);

            //Sprawdzenie czy obliczona cyfra jest zgodna z cyfrą w PESEL
            if (calculatedFirstControlDigit != firstControlDigit) return false;

            //Obliczanie drugie cyfry kontrolnej
            sum = 0;
            for(int i = 0; i < 10; i++)
            {
                sum += Int32.Parse(IdNumber.Substring(i, 1)) * multipliersForSecondControlDigit[i];
            }
            int calculatedSecondControlDigit = 11 - (sum % 11);

            //Sprawdzenie czy obliczona cyfra jest zgodna z cyfrą w PESEL
            if (calculatedSecondControlDigit != secondControlDigit) return false;

            return true;
        }
    }
}
