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
            string query = "SELECT Cars.Model, Teams.Name AS 'Team Name', Engines.Manufacturer AS 'EngineManufacturer', Brakes.Manufacturer AS 'BrakeManufacturer', Cars.YearOfReveal, Cars.Id, Teams.Id As 'TeamId' " +
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

        /// <summary>
        /// Metoda zwracająca szczegółowe dane o danym zespole
        /// </summary>
        /// <param name="teamId">ID wybranego zespołu</param>
        /// <returns></returns>
        public DataTable GetTeamDetails(int teamId)
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Teams.Name, Teams.ConstructorsChampionshipTitles, Teams.Base, TeamPrincipals.FirstName, TeamPrincipals.LastName, Driver1.FirstName AS 'FirstDriverName', Driver1.LastName AS 'FirstDriverLastName', Driver2.FirstName AS 'SecondDriverFirstName' , Driver2.LastName AS 'SecondDriverLastName' " +
                           "FROM Teams " +
                           "JOIN TeamPrincipals ON TeamPrincipals.Id = Teams.TeamPrincipalId " +
                           "JOIN Drivers AS Driver1 ON Driver1.Id = Teams.FirstDriverId " +
                           "JOIN Drivers AS Driver2 ON Driver2.Id = Teams.SecondDriverId " +
                           $"WHERE Teams.Id = {teamId};";



            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }

        /// <summary>
        /// Metoda zwracająca szczegółowe dane o danym samochodzie
        /// </summary>
        /// <param name="carId">ID wybranego samochodu</param>
        /// <returns></returns>
        public DataTable GetCarDetails(int carId)
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Cars.Model, Designers.FirstName, Designers.LastName, Engines.Manufacturer, Engines.Model,  Gearboxes.Manufacturer, Brakes.Manufacturer, Brakes.Model, Tyres.Manufacturer, Cars.Length, Cars.Width " +
                           "FROM Cars " +
                           "JOIN Designers ON Designers.Id = Cars.DesignerId " +
                           "JOIN Engines ON Engines.Id = Cars.EngineId " +
                           "JOIN Gearboxes ON Gearboxes.Id = Cars.GearboxId " +
                           "JOIN Brakes ON Brakes.Id = Cars.BrakesId " +
                           "JOIN Tyres ON Tyres.Id = Cars.TyreId " +
                           $"WHERE Cars.Id = {carId};";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }


    }
}
