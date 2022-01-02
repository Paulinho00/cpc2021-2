using PawełGryglewiczLab6PracDom.Models.Dtos.RoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// Metoda zwracająca wszystkie sale
        /// </summary>
        /// <returns></returns>
        List<RoomDtoForGetResponses> GetAll();

        /// <summary>
        /// Metoda zwracająca salę o danym id
        /// </summary>
        /// <param name="id">id pokoju</param>
        /// <returns></returns>
        RoomDtoForGetResponses GetById(int id);

        /// <summary>
        /// Metoda zwracająca salę o danym numerze z danego budynku
        /// </summary>
        /// <param name="category">Kategoria budynku</param>
        /// <param name="buildingNumber">Numer budynku</param>
        /// <param name="roomNumber">Numer sali</param>
        /// <returns></returns>
        RoomDtoForGetResponses GetByNumber(char category, int buildingNumber, int roomNumber);

        /// <summary>
        /// Metoda zwracająca wszystkie sale w danym budynku
        /// </summary>
        /// <param name="category">Kategoria budynku</param>
        /// <param name="number">Numer budynku</param>
        /// <returns></returns>
        List<RoomDtoForGetResponses> GetByBuilding(char category, int number);


        /// <summary>
        /// Metoda usuwająca salę o danym id
        /// </summary>
        /// <param name="id">Id sali</param>
        /// <returns></returns>
        bool DeleteById(int id);

        /// <summary>
        /// Metoda usuwająca salę o danym numerze z danego budynku
        /// </summary>
        /// <param name="category">Kategoria budynku</param>
        /// <param name="buildingNumber">Numer budynku</param>
        /// <param name="roomNumber">Numer sali</param>
        /// <returns></returns>
        bool DeleteByNumber(char category, int buildingNumber, int roomNumber);

        /// <summary>
        /// Metoda edytująca salę o danym Id
        /// </summary>
        /// <param name="id">Id sali</param>
        /// <param name="roomDto">Zmodyfikowany obiekt sali</param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -1: Nie ma takiej sali
        /// -2: Nie ma budynku o takim id
        /// -3: Numer sali nie może się powtarzać w danym budynku
        /// -4: Nie ma takiego piętra w danym budynku
        /// -5: Numer sali musi być większy od 0
        /// -6: Liczba miejsc nie jest poprawna (nie jest >=2)
        /// </returns>
        int PutById(int id, RoomDtoForPostPutResponses roomDto);

        /// <summary>
        /// Metoda edytujaca salę o danym numerze z danego budynku
        /// </summary>
        /// <param name="category">Kategoria budynku</param>
        /// <param name="buildingNumber">Numer budynku</param>
        /// <param name="roomNumber">Numer sali</param>
        /// <param name="roomDto">Zmodyfikowany obiekt sali</param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -1: Nie ma takiej sali
        /// -2: Nie ma budynku o takim id
        /// -3: Numer sali nie może się powtarzać w danym budynku
        /// -4: Nie ma takiego piętra w danym budynku
        /// -5: Numer sali musi być większy od 0
        /// -6: Liczba miejsc nie jest poprawna (nie jest >=2)
        /// </returns>
        int PutByNumber(char category, int buildingNumber, int roomNumber, RoomDtoForPostPutResponses roomDto);

        /// <summary>
        /// Metoda dodająca salę do budynku z danym id
        /// </summary>
        /// <param name="roomDto">Utworzony obiekt nowej sali</param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -2: Nie ma budynku o takim id
        /// -3: Numer sali nie może się powtarzać w danym budynku
        /// -4: Nie ma takiego piętra w danym budynku
        /// -5: Numer sali musi być większy od 0
        /// -6: Liczba miejsc nie jest poprawna (nie jest >=2)
        /// </returns>
        int Post(RoomDtoForPostPutResponses roomDto);

    }
}
