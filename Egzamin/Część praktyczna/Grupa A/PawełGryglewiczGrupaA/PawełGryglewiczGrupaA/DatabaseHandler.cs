using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawełGryglewiczGrupaA
{
    /// <summary>
    /// Klasa zarządzająca komunikacją z bazą danych
    /// </summary>
    class DatabaseHandler
    {
        /// <summary>
        /// Połączenie z bazą danych
        /// </summary>
        private readonly SqlConnection _connection = new SqlConnection(Properties.Resources.ConnectionString);


        /// <summary>
        /// Metoda zwracająca rekord z bazy danych z odpowiednim imieniem
        /// </summary>
        /// <returns></returns>
        public DataTable GetRecords()
        {
            string firstLetter = "Jan";
            //Zapytanie sql
            string query = $"SELECT * FROM Clients WHERE Clients.name = {firstLetter};";

            //Pobranie danych z bazy
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, _connection);
            DataTable records = new DataTable();
            sqlDataAdapter.Fill(records);
            return records;
        }
    }
}
