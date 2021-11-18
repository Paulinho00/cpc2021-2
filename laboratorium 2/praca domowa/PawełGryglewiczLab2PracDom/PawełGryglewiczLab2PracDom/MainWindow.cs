using PawełGryglewiczLab2PracDom.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawełGryglewiczLab2PracDom
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu obsługującego bazę danych
        /// </summary>
        private readonly DatabaseHandler _databaseHandler = new DatabaseHandler();

        public MainWindow()
        {
            InitializeComponent();
            //Pobranie danych wszystkich aut z bazy danych
            DataTable table = _databaseHandler.GetCars();
            //Odświeżenie danych w dataGridViewCars
            dataGridViewCars.DataSource = table;
        }
    }
}
