﻿using PawełGryglewiczLab6PracDom.Models.Dtos.LessonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Interfaces
{
    public interface ILessonService
    {
        /// <summary>
        /// Metoda zwracająca wszystkie zapisane zajęcia w bazie danych
        /// </summary>
        /// <returns></returns>
        List<LessonDtoForGetResponses> GetAll();

        /// <summary>
        /// Metoda zwracająca zajęcia o danym id
        /// </summary>
        /// <param name="id">Id zajęć</param>
        /// <returns></returns>
        LessonDtoForGetResponses GetById(int id);

        /// <summary>
        /// Metoda zwracająca zajęcia prowadzone przez prowadzącego o danym id
        /// </summary>
        /// <param name="lecturerId">Id prowadzącego</param>
        /// <returns></returns>
        List<LessonDtoForGetResponses> GetByLecturerId(int lecturerId);

        /// <summary>
        /// Metoda zwracająca zajęcia odbywające się w sali o danym id
        /// </summary>
        /// <param name="roomId">Id sali</param>
        /// <returns></returns>
        List<LessonDtoForGetResponses> GetByRoomId(int roomId);

        /// <summary>
        /// Metoda usuwająca zajęcia o danym id z bazy danych
        /// </summary>
        /// <param name="id">Id zajęć</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Metoda edytująca zajęcia o danym id
        /// </summary>
        /// <param name="id">Id zajęć</param>
        /// <param name="lessonDto">Obiekt ze zmodyfikowanymi danymi zajęć</param>
        /// <returns></returns>
        int Put(int id, LessonDtoForPostPutResponses lessonDto);

        /// <summary>
        /// Metoda dodająca zajęcia do bazy danych
        /// </summary>
        /// <param name="lessonDto">Obiekt z danymi nowych zajęć</param>
        /// <returns></returns>
        int Post(LessonDtoForPostPutResponses lessonDto);
    }
}
