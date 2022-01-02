using PawełGryglewiczLab6PracDom.Models.Dtos.LecturerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Interfaces
{
    public interface ILecturerService
    {
        /// <summary>
        /// Metoda zwracająca wszystkich prowadzących z bazy danych
        /// </summary>
        /// <returns></returns>
        List<LecturerDtoForGetResponses> GetAll();

        /// <summary>
        /// Metoda zwracająca prowadzącego z danym id
        /// </summary>
        /// <param name="id">Id prowadzącego</param>
        /// <returns></returns>
        LecturerDtoForGetResponses GetById(int id);

        /// <summary>
        /// Metoda zwracająca prowadzących z danego wydzialu
        /// </summary>
        /// <param name="facultyId">Id wydziału</param>
        /// <returns></returns>
        List<LecturerDtoForGetResponses> GetByFacultyId(int facultyId);

        /// <summary>
        /// Metoda zwracająca prowadzących z danego wydziału
        /// </summary>
        /// <param name="facultyNumber">Numer wydziału</param>
        /// <returns></returns>
        List<LecturerDtoForGetResponses> GetByFacultyNumber(int facultyNumber);

        /// <summary>
        /// Metoda usuwająca prowadzącego o danym id
        /// </summary>
        /// <param name="id">Id prowadzącego</param>
        /// <returns></returns>
        public bool Delete(int id);

        /// <summary>
        /// Metoda edytująca prowadzącego o danym id
        /// </summary>
        /// <param name="id">Id prowadzącego</param>
        /// <param name="lecturerDto">Zmodyfikowany obiekt prowadzącego</param>
        /// <returns></returns>
        public int Put(int id, LecturerDtoForPostPutResponses lecturerDto);

        /// <summary>
        /// Metoda dodająca nowego prowadzącego do bazy danych
        /// </summary>
        /// <param name="lecturerDto">Utworzony obiekt prowadzącego</param>
        /// <returns></returns>
        public int Post(LecturerDtoForPostPutResponses lecturerDto);

    }
}
