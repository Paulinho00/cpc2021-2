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

        /// <summary>
        /// Odświeża szczegółowe dane zespołu i auta
        /// </summary>
        /// <param name="teamId"></param>
        private void RefreshDetails(int teamId)
        {
            //Pobranie danych o zespole z bazy danych
            DataTable teamDetails = _databaseHandler.GetTeamDetails(teamId);

            //Wyświetlenie nazwy aktualnie zespołu do którego należy zaznaczone auto
            labelTeamNameValue.Text = teamDetails.Rows[0][0].ToString();
            //Wyświetlenie liczby zdobytych tytułów przez zespół
            labelChampionshipTitlesNumber.Text = teamDetails.Rows[0][1].ToString();
            //Wyświetlenie kraju pochodzenia zespołu
            labelBaseLocation.Text = teamDetails.Rows[0][2].ToString();
            //Wyświetlenie imienia i nazwiska szefa zespołu
            labelTeamPrincipalName.Text = teamDetails.Rows[0][3].ToString() + " " + teamDetails.Rows[0][4].ToString();
            //Wyświetlenie imienia i nazwiska pierwszego kierowcy
            labelFirstDriverName.Text = teamDetails.Rows[0][5].ToString() + " " + teamDetails.Rows[0][6].ToString();
            //Wyświetlenie imienia i nazwiska drugiego kierowcy
            labelSecondDriverName.Text = teamDetails.Rows[0][7].ToString() + " " + teamDetails.Rows[0][8].ToString();

        }

        /// <summary>
        /// Metoda wykonywana za każdym razem gdy użytkownik zmieni zaznaczenie wiersza w dataGridViewCars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCars_SelectionChanged(object sender, EventArgs e)
        {
            //Sprawdzenie czy użytkownik zaznaczył tylko jeden wiersz
            int rowCount = dataGridViewCars.SelectedRows.Count;
            if(rowCount != 1)
            {
                //Wyjście z metody
                return;
            }
            //Wywołanie metody odświeżającej dane w głównym okniue
            RefreshDetails((int)dataGridViewCars.SelectedRows[0].Cells[6].Value);
        }
    }
}
