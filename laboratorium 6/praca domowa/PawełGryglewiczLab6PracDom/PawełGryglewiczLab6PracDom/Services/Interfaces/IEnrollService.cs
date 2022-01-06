using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services.Interfaces
{
    public interface IEnrollService
    {

        /// <summary>
        /// Metoda usuwająca zapis studenta na dane zajęcia
        /// </summary>
        /// <param name="studentId">Id studenta</param>
        /// <param name="lessonId">Id zajęć</param>
        /// <returns></returns>
        bool Delete(int studentId, int lessonId);

        /// <summary>
        /// Metoda zapisująca studenta na dane zajęcia
        /// </summary>
        /// <param name="studentId">Id studenta</param>
        /// <param name="lessonId">Id zajęć</param>
        /// <returns></returns>
        int Post(int studentId, int lessonId);

        /// <summary>
        /// Metoda edytujaca zapis danego studenta na zajęcia
        /// </summary>
        /// <param name="studentId">Id studenta</param>
        /// <param name="lessonId">Id zajęć</param>
        /// <returns></returns>
        int Put(int studentId, int lessonId);
    }
}
