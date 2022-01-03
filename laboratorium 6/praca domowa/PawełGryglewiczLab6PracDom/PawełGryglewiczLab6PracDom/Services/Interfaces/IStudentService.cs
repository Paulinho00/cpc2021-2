using PawełGryglewiczLab6PracDom.Models.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// Metoda zwracająca wszystkich studentów z bazy danych
        /// </summary>
        /// <returns></returns>
        List<StudentDtoForGetResponses> GetAll();

        /// <summary>
        /// Metoda zwracająca dane studenta o danym id
        /// </summary>
        /// <param name="id">Id studenta</param>
        /// <returns></returns>
        StudentDtoForGetResponses GetById(int id);

        /// <summary>
        /// Metoda zwracająca studentów należących do wydziału o danym id
        /// </summary>
        /// <param name="facultyId">Id wydziału</param>
        /// <returns></returns>
        List<StudentDtoForGetResponses> GetByFacultyId(int facultyId);

        /// <summary>
        /// Metoda zwracająca studentów należących do wydziału o danym numerze
        /// </summary>
        /// <param name="facultyNumber">Numer wydziału</param>
        /// <returns></returns>
        List<StudentDtoForGetResponses> GetByFacultyNumber(int facultyNumber);

        /// <summary>
        /// Metoda zwracająca studenta o danym indeksie
        /// </summary>
        /// <param name="index">Indeks wybranego studenta</param>
        /// <returns></returns>
        StudentDtoForGetResponses GetByIndex(int index);

        /// <summary>
        /// Metoda usuwająca studenta o danym id
        /// </summary>
        /// <param name="id">Id studenta</param>
        /// <returns></returns>
        public bool DeleteById(int id);

        /// <summary>
        /// Metoda usuwająca studenta o danym indeksie
        /// </summary>
        /// <param name="index">Indeks wybranego studenta</param>
        /// <returns></returns>
        public bool DeleteByIndex(int index);

        /// <summary>
        /// Metoda edytująca dane studenta o danym id
        /// </summary>
        /// <param name="id">Id studenta</param>
        /// <param name="studentDto">Obiekt ze zmodyfikowanymi danymi studenta </param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -1: Nie zgadza się długość PESEL lub zawiera niedozwolne znaki
        /// -2: Numer PESEL powtarza się
        /// -3: Indeks nie mieści się w zakresie <200001; 299999>
        /// -4: Numer indeksu powtarza się
        /// -5: Nie ma wydziału o takim id
        /// -6: Nie ma studenta o takim id
        /// </returns>
        public int PutById(int id, StudentDtoForPostPutResponses studentDto);

        /// <summary>
        /// Metoda edytująca dane studenta o danym indeksie
        /// </summary>
        /// <param name="index">Indeks wybranego studenta </param>
        /// <param name="studentDto">Obiekt ze zmodyfikowanymi danymi studenta</param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -1: Nie zgadza się długość PESEL lub zawiera niedozwolne znaki
        /// -2: Numer PESEL powtarza się
        /// -3: Indeks nie mieści się w zakresie <200001; 299999>
        /// -4: Numer indeksu powtarza się
        /// -5: Nie ma wydziału o takim id
        /// -6: Nie ma studenta o takim indeksie
        /// </returns>
        public int PutByIndex(int index, StudentDtoForPostPutResponses studentDto);

        /// <summary>
        /// Metoda dodająca nowego studenta do bazy danych
        /// </summary>
        /// <param name="studentDto">Obiekt z danymi nowego studenta </param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -1: Nie zgadza się długość PESEL lub zawiera niedozwolne znaki
        /// -2: Numer PESEL powtarza się
        /// -3: Indeks nie mieści się w zakresie <200001; 299999>
        /// -4: Numer indeksu powtarza się
        /// -5: Nie ma wydziału o takim id
        /// </returns>
        public int Post(StudentDtoForPostPutResponses studentDto);
    }
}
