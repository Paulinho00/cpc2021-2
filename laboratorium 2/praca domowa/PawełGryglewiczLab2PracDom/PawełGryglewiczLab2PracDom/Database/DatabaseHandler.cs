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
    public class DatabaseHandler
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

        /// <summary>
        /// Metoda zwracająca wszystkie dostępne zespoły w bazie danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetTeams()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Name, Id FROM Teams;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;

        }

        /// <summary>
        /// Metoda zwracająca wszystkich projektantów należących do danego zespołu
        /// </summary>
        /// <param name="teamId">Id wybranego zespołu</param>
        /// <returns></returns>
        public DataTable GetDesigners()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT FirstName, LastName, Id FROM Designers;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie dostępna skrzynie biegów w bazie danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetGearboxes()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Manufacturer, Id FROM Gearboxes;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie dostępne opony w bazie danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetTyres()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Manufacturer, FrontTyresWidth, Id FROM Tyres;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie dostępne hamulce w bazie danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetBrakes()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Manufacturer, Model, Id FROM Brakes;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie dostepne silniki w bazie danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetEngines()
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT Manufacturer, Model, Id FROM Engines;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;
        }

        /// <summary>
        /// Metoda zwracająca dane samochodu z podanym Id
        /// </summary>
        /// <param name="carId">Id wybranego samochodu</param>
        /// <returns></returns>
        public DataTable getCar(int carId)
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "SELECT * FROM Cars " +
                           $"WHERE Id = {carId};";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable dataFromQuery = new DataTable();
            //Pobranie danych z bazy
            adapter.Fill(dataFromQuery);
            //Zwrócenie wyników zapytania
            return dataFromQuery;

        }

        /// <summary>
        /// Metoda dodająca rekord do bazy danych
        /// </summary>
        /// <param name="name">nazwa modelu samochodu</param>
        /// <param name="yearOfReveal">rok debiutu samochodu </param>
        /// <param name="teamId">ID zespołu posiadającego samochodu</param>
        /// <param name="designerId">ID projektanta samochodu</param>
        /// <param name="gearboxId">ID skrzyni biegów samochodu</param>
        /// <param name="tyresId">ID opon samochodu</param>
        /// <param name="length">długość samochodu</param>
        /// <param name="width">szerokość samochodu</param>
        /// <param name="brakeId">ID hamulców samochodu</param>
        /// <param name="engineId">ID silnika samochodu</param>
            public void InsertCar(String name, int yearOfReveal, int teamId, int designerId, int gearboxId, int tyresId, int length, int width, int brakeId, int engineId)
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "INSERT INTO Cars (Model, YearOfReveal, DesignerId, BrakesId, GearboxId, TyreId, Length, Width, TeamId, EngineId) " +
                           $"VALUES ('{name}', {yearOfReveal}, {designerId}, {brakeId}, {gearboxId}, {tyresId}, {length}, {width}, {teamId}, {engineId});";

            //Otwarcie połączenia z bazą danych
            _connection.Open();
            //Stworzenie komendy sql
            SqlCommand commandInsertCar = new SqlCommand(query, _connection);
            //Wykonanie komendy
            commandInsertCar.ExecuteNonQuery();
            //Zamknięcie połączenia
            _connection.Close();
        }

        /// <summary>
        /// Metoda modyfikująca rekord o podanym ID w bazie danych
        /// </summary>
        /// <param name="name">nowa nazwa modelu samochodu</param>
        /// <param name="yearOfReveal">nowy rok debiutu samochodu </param>
        /// <param name="teamId">nowe ID zespołu posiadającego samochodu</param>
        /// <param name="designerId">nowe ID projektanta samochodu</param>
        /// <param name="gearboxId">nowe ID skrzyni biegów samochodu</param>
        /// <param name="tyresId">nowe ID opon samochodu</param>
        /// <param name="length">nowa długość samochodu</param>
        /// <param name="width">nowa szerokość samochodu</param>
        /// <param name="brakeId">nowe ID hamulców samochodu</param>
        /// <param name="engineId">nowe ID silnika samochodu</param>
        /// <param name="Id">ID modyfikowanego samochodu</param>
        public void UpdateCar(String name, int yearOfReveal, int teamId, int designerId, int gearboxId, int tyresId, int length, int width, int brakeId, int engineId, int Id)
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = "UPDATE Cars " +
                           $"SET Model = '{name}', YearOfReveal = {yearOfReveal}, DesignerId = {designerId}, BrakesId = {brakeId}, GearboxId = {gearboxId}, TyreId = {tyresId}, Length = {length}, Width = {width}, TeamId = {teamId}, EngineId = {engineId} " +
                           $"WHERE Id = {Id};";
            //Otwarcie połączenia z bazą danych
            _connection.Open();
            //Stworzenie komendy sql
            SqlCommand commandInsertCar = new SqlCommand(query, _connection);
            //Wykonanie komendy
            commandInsertCar.ExecuteNonQuery();
            //Zamknięcie połączenia
            _connection.Close();
        }

        /// <summary>
        /// Metoda usuwająca dany samochód z bazy danych
        /// </summary>
        /// <param name="carId">ID usuwanego samochodu</param>
        public void DeleteCar(int carId)
        {
            //Zmienna przechowująca zapytanie do bazy danych
            string query = $"DELETE FROM Cars WHERE Id = {carId};";
            //Otwarcie połączenia z bazą danych
            _connection.Open();
            //Stworzenie komendy sql
            SqlCommand commandInsertCar = new SqlCommand(query, _connection);
            //Wykonanie komendy
            commandInsertCar.ExecuteNonQuery();
            //Zamknięcie połączenia
            _connection.Close();
        }


    }
}
