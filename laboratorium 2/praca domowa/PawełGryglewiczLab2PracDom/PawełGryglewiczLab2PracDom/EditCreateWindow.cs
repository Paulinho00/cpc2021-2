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
    public partial class EditCreateWindow : Form
    {
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu obsługującego połączenie z bazą danych
        /// </summary>
        private readonly DatabaseHandler _databaseHandler;
        /// <summary>
        /// Zmienna przechowująca wynik zapytania do bazy danych z dostepnymi zespołami
        private DataTable teams;
        /// <summary>
        /// Zmienna przechowująca wynik zapytania do bazy danych z dostępymi projektantami dla danego zespołu
        /// </summary>
        private DataTable designers;
        /// <summary>
        /// Zmienna przechowująca wynik zapytania do bazy danych z dostępnymi skrzyniami biegów
        /// </summary>
        private DataTable gearboxes;
        /// <summary>
        /// Zmienna przechowująca wynik zapytania do bazy danych z dostępnymi oponami
        /// </summary>
        private DataTable tyres;
        /// <summary>
        /// Zmienna przechowująca wynik zapytania do bazy danych z dostepnymi hamulcami
        /// </summary>
        private DataTable brakes;
        /// <summary>
        /// Zmienna przechowująca wynik zapytania do bazy danych z dostępnymi hamulcami
        /// </summary>
        private DataTable engines;
        /// <summary>
        /// Zmienna przechowująca refenrecję do obiektu głównego okna
        /// </summary>
        private readonly MainWindow mainWindow;

        public EditCreateWindow(DatabaseHandler databaseHandlerFromMainWindow, MainWindow mainWindow)
        {
            InitializeComponent();
            Visible = true;
            _databaseHandler = databaseHandlerFromMainWindow;
            this.mainWindow = mainWindow;
            RefreshComboBoxes();
        }

        /// <summary>
        /// Metoda odświeżająca dane w comboBoxach
        /// </summary>
        private void RefreshComboBoxes()
        {
            //Pobranie nazw i ID wszystkich zespołów
            teams = _databaseHandler.GetTeams();

            //Dodanie zespołów do comboBoxa
            for (int i = 0; i < teams.Rows.Count; i++)
            {
                comboBoxTeams.Items.Add(i + 1 + ". " + teams.Rows[i][0].ToString());
            }

            //Pobranie imion, nazwisk i ID, projektantów danego zespołu
            designers = _databaseHandler.GetDesigners();
            //Dodanie projektantów do comboBoxa
            for (int i = 0; i < designers.Rows.Count; i++)
            {
                 comboBoxDesigners.Items.Add(i + 1 + ". " + designers.Rows[i][0] + " " + designers.Rows[i][1]);
            }

            //Pobranie nazw producentów i ID z bazy danych ze skrzyniami biegów
            gearboxes = _databaseHandler.GetGearboxes();
            for (int i = 0; i < gearboxes.Rows.Count; i++)
            {
                //Dodanie dostepnych skrzyń biegów do comboBoxa
                comboBoxGearboxes.Items.Add(i + 1 + ". " + gearboxes.Rows[i][0]);
            }

            //Pobranie nazw producentów, szerokości przednich kół i ID z bazy danych z oponami
            tyres = _databaseHandler.GetTyres();
            for (int i = 0; i < tyres.Rows.Count; i++)
            {
                //Dodanie dostepnych opon do comboBoxa
                comboBoxTyres.Items.Add(i + 1 + ". " + tyres.Rows[i][0] + " " + tyres.Rows[i][1].ToString() + "mm");
            }

            //Pobranie nazw producentów, modelu i ID hamulców z bazy danych
            brakes = _databaseHandler.GetBrakes();
            for (int i = 0; i < brakes.Rows.Count; i++)
            {
                //Dodanie hamulców do comboBoxa
                comboBoxBrakes.Items.Add(i + 1 + ". " + brakes.Rows[i][0] + " " + brakes.Rows[i][1]);
            }

            //Pobranie nazw producentów, modelu i ID silników z bazy danych
            engines = _databaseHandler.GetEngines();
            for (int i = 0; i < engines.Rows.Count; i++)
            {
                //Dodanie silników do comboBoxa
                comboBoxEngines.Items.Add(i + 1 + ". " + engines.Rows[i][0] + " " + engines.Rows[i][1]);
            }

        }

        /// <summary>
        /// Przycisk potwierdzający tworzenie nowego samochodu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //Sprawdzenie czy użytkownik wypełnił wszystkie pola
            try
            {
                //Wczytanie nazwy modelu samochodu
                string name = textBoxCarName.Text;
                //Wczytanie roku debiutu
                int yearOfReveal = Decimal.ToInt32(numericUpDownYearOfReveal.Value);
                //Wczytanie ID zespołu właścicielskiego samochodu
                int teamId = (int)teams.Rows[(int)Char.GetNumericValue(comboBoxTeams.SelectedItem.ToString()[0]) - 1][1];
                //Wczytanie ID projektanta samochodu
                int designerId = (int)designers.Rows[(int)Char.GetNumericValue(comboBoxDesigners.SelectedItem.ToString()[0]) - 1][2];
                //Wczytanie ID skrzyni biegów samochodu
                int gearboxId = (int)gearboxes.Rows[(int)Char.GetNumericValue(comboBoxGearboxes.SelectedItem.ToString()[0]) - 1][1];
                //Wczytanie ID opon samochodu
                int tyresId = (int)tyres.Rows[(int)Char.GetNumericValue(comboBoxTyres.SelectedItem.ToString()[0]) - 1][2];
                //Wczytanie długości samochodu
                int length = Decimal.ToInt32(numericUpDownLength.Value);
                //Wczytanie szerekości samochodu
                int width = Decimal.ToInt32(numericUpDownWidth.Value);
                //Wczytanie ID hamulców samochodu
                int brakeId = (int)brakes.Rows[(int)Char.GetNumericValue(comboBoxBrakes.SelectedItem.ToString()[0]) - 1][2];
                //Wczytanie ID silnika samochodu
                int engineId = (int)engines.Rows[(int)Char.GetNumericValue(comboBoxEngines.SelectedItem.ToString()[0]) - 1][2];
                //Wywołanie metody dodającej rekord do bazy danych
                _databaseHandler.InsertCar(name, yearOfReveal, teamId, designerId, gearboxId, tyresId, length, width, brakeId, engineId);
                //Odświezenie dataGridu w głównym oknie
                mainWindow.RefreshDataGrid();
                //Zamknięcie okna tworzenia nowego samochodu
                Close();
            }
            catch (NullReferenceException)
            {
                //Wyświetlenie informacji o nie wypełnieniu wszystkich pól
                MessageBox.Show("Nie wypełniłeś wszystkich pól");
            }
        }

        /// <summary>
        /// Przycisk zamykający okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //Zamknięcie okna
            Close();
        }
    }   
}
