using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawełGryglewiczLab2PracDom.Database
{
    /// <summary>
    /// Klasa zarządzająca połączeniem z bazą danych i wysyłająca do niej zapytania
    /// </summary>
    class DatabaseHandler
    {
        /// <summary>
        /// Zmienna przechowująca połączenie z bazą danych
        /// </summary>
        private readonly SqlConnection _connection = new SqlConnection(Properties.Resources.ConnectionString);

        /// <summary>
        /// Metoda zwracająca dane o wszystkich samochodach z bazy danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetCars()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Cars.Id, Cars.Model, Teams.Name AS 'Team Name', Engines.Manufacturer AS 'Engine Manufacturer', Brakes.Manufacturer AS 'Brake Manufacturer', Cars.YearOfReveal " +
                           "FROM Cars " +
                           "JOIN Teams ON Teams.Id = Cars.TeamId " +
                           "JOIN Engines ON Engines.Id = Cars.EngineId " +
                           "JOIN Brakes ON Brakes.Id = Cars.BrakesId;";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }
        


    }
}
