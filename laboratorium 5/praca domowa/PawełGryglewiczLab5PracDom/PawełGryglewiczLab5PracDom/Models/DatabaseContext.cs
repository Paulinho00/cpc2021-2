using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5PracDom.Models
{
    /// <summary>
    /// Klasa będąca modelem bazy danych
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
  
        }

        /// <summary>
        /// Tabela ze stacjami
        /// </summary>
        public DbSet<Station> Stations { get; set; }

        /// <summary>
        /// Tabela z pociągami
        /// </summary>
        public DbSet<Train> Trains { get; set; }

        /// <summary>
        /// Tabela z połączeniami kolejowymi
        /// </summary>
        public DbSet<RailwayConnection> RailwayConnections { get; set; }

        /// <summary>
        /// Tabela z pasażerami
        /// </summary>
        public DbSet<Passenger> Passengers { get; set; }
    }
}
