using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab6PracDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab6PracDom.Services
{
    /// <summary>
    /// Model bazy danych
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        /// <summary>
        /// Tabela ze studentami
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Tabela z prowadzącymi
        /// </summary>
        public DbSet<Lecturer> Lecturers { get; set; }

        /// <summary>
        /// Tabela z budynkami
        /// </summary>
        public DbSet<Building> Buildings { get; set; }

        /// <summary>
        /// Tabela z salami zajęciowymi
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// Tabela z wydziałami
        /// </summary>
        public DbSet<Faculty> Faculties { get; set; }

        /// <summary>
        /// Tabela z zajęciami
        /// </summary>
        public DbSet<Lesson> Lessons { get; set; }
    }
}
