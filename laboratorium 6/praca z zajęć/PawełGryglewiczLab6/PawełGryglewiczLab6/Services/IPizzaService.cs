using PawełGryglewiczLab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6.Services
{
    public interface IPizzaService
    {
        /// <summary>
        /// Metoda zwraca wszytkie pizze
        /// </summary>
        /// <returns></returns>
        List<Pizza> Get();

        /// <summary>
        /// Metoda dodaje nową pizzę i zwraca jej id
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns></returns>
        int Post(Pizza pizza);

        /// <summary>
        /// Metoda edytuje wskazaną pizze 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pizza"></param>
        /// <returns></returns>
        bool Put(int id, Pizza pizza);

        /// <summary>
        /// Metoda usuwa wskazaną pizze
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
