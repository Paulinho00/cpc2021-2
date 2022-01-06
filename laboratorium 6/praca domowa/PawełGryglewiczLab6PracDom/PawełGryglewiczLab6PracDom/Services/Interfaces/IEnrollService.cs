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
        /// Metoda zapisująca danego studenta na zajęcia
        /// </summary>
        /// <param name="studentId">Id studenta</param>
        /// <param name="lessonId">Id zajęć</param>
        /// <returns> Liczbę odpowiadającą odpowiedniemu komunikatowi
        ///  0: operacja przebiegła pomyślnie
        /// -1: Student ma już zajęcia w tym czasie
        /// -2: Na zajęciach nie ma wystarczającej liczby miejsc
        /// -3: Nie ma zajęć lub studenta o takim id
        /// </returns>
        int Post(int studentId, int lessonId);
    }
}
