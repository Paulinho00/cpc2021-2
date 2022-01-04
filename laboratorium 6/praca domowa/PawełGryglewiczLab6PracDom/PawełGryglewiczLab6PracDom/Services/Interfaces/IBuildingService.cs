using PawełGryglewiczLab6PracDom.Models.Dtos.BuildingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Interfaces
{
    public interface IBuildingService
    {
        /// <summary>
        /// Zapytanie GET zwracające wszystkie budynki
        /// </summary>
        /// <returns></returns>
        List<BuildingDtoForGetResponse> GetAll();

        /// <summary>
        /// Zapytanie GET zwracające wszystkie budynki należące do danego wydziału 
        /// </summary>
        /// <param name="facultyId">Id wydziału</param>
        /// <returns></returns>
        List<BuildingDtoForGetResponse> GetByFaculty(int facultyId);

        /// <summary>
        /// Zapytanie GET zwracające budynek z danej kategorii i o danym numerze
        /// </summary>
        /// <param name="category">kategoria budynku</param>
        /// <param name="number">numer budynku</param>
        /// <returns></returns>
        BuildingDtoForGetResponse GetByCategoryAndNumber(char category, int number);

        /// <summary>
        /// Zapytanie GET zwracające budynek o danym id
        /// </summary>
        /// <param name="id">Id budynku</param>
        /// <returns></returns>
        BuildingDtoForGetResponse GetById(int id);

        /// <summary>
        /// Zapytanie DELETE usuwające budynek o danym id
        /// </summary>
        /// <param name="id">Id budynku</param>
        /// <returns></returns>
        bool DeleteById(int id);

        /// <summary>
        /// Zapytanie DELETE usuwające budynek o danej kategorii i o danym numerze
        /// </summary>
        /// <param name="category">kategoria budynku</param>
        /// <param name="number">numer budynku</param>
        /// <returns></returns>
        bool DeleteByCategoryAndNumber(char category, int number);

        /// <summary>
        /// Zapytanie PUT edytujące budynek o danym id
        /// </summary>
        /// <param name="id">Id budynku</param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0 :operacja przebiegła pomyślnie
        /// -1: Numer w danej kategorii powtarza się
        /// -2: Nie ma wydziału o takim numerze id
        /// -3: Nie ma budynku o takim numerze id
        /// -4: Rok budowy nie mieści się w przedziale <1900;2021>
        /// -5: Liczba pięter nie mieści się w przedziale <1;20>
        /// -6: Kategoria nie jest literą
        /// -7: Numer nie może być ujemny
        /// </returns>
        int Put(int id, BuildingDtoForPostPutResponse buildingDto);

        /// <summary>
        /// Zapytanie POST dodające nowy budynek
        /// </summary>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0 :operacja przebiegła pomyślnie
        /// -1: Numer w danej kategorii powtarza się
        /// -2: Nie ma wydziału o takim numerze id
        /// -4: Rok budowy nie mieści się w przedziale <1900;2021>
        /// -5: Liczba pięter nie mieści się w przedziale <1;20>
        /// -7: Numer nie może być ujemny
        /// </returns>
        int Post(BuildingDtoForPostPutResponse buildingDto);
    }
}
