using PawełGryglewiczLab6PracDom.Models;
using PawełGryglewiczLab6PracDom.Models.Dtos;
using PawełGryglewiczLab6PracDom.Models.Dtos.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services
{
    public interface IFacultyService
    {
        /// <summary>
        /// Metoda zwraca wszystkie wydziały
        /// </summary>
        /// <returns></returns>
        List<FacultyDtoForGetResponse> GetAll();

        /// <summary>
        /// Metoda zwraca wydział o danym Id
        /// </summary>
        /// <param name="id">Numer id wydziału</param>
        /// <returns></returns>
        FacultyDtoForGetResponse GetById(int id);

        /// <summary>
        /// Metoda dodaje nowy wydział i zwraca jego id
        /// </summary>
        /// <param name="faculty">Nowy wydział</param>
        /// <returns></returns>
        bool Post(FacultyDtoForPostPutResponse facultyDto);

        /// <summary>
        /// Metoda edytuje wydział o podanym id
        /// </summary>
        /// <param name="id">Id edytowanego wydziału</param>
        /// <param name="faculty">Zmodyfikowany wydział</param>
        /// <returns></returns>
        bool Put(int id, FacultyDtoForPostPutResponse faculty);

        /// <summary>
        /// Usuwa wydział o danym Id
        /// </summary>
        /// <param name="id">Id usuwanego wydziału</param>
        /// <returns></returns>
        bool DeleteById(int id);

    }
}
