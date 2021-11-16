using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using CPC2021_2_Lab2.Database;

namespace CPC2021_2_Lab2.Forms
{
    /// <summary>
    /// Klasa okna głównego aplikacji
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// Konstruktor okna głownego aplikacji
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            //Ustawienie okna, żeby pojawiało się na środku ekranu
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Aktualizacja danych w DataGridViewBooks przy ładowaniu okna
            RefreshDataGridViewBooks();

            //Dostosowanie tabeli DataGridViewBooks przy ładowaniu okna
            CustomizeDataGridViewBooks();
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku do dodawania nowej książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            string title = textBoxBookTitle.Text;
            int yearOfPublish = int.Parse(textBoxYearOfPublication.Text);
            int price = int.Parse(textBoxPrice.Text);
            string genre = textBoxGenre.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;

            _repository.AddBook(title,yearOfPublish,price, genre, firstName, lastName);

            RefreshDataGridViewBooks();
            ClearTextBoxes();
            labelLastAction.Text = "Dodano książkę";
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku do usuwania książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(textBoxId.Text);

            _repository.DeleteBook(bookId);
            RefreshDataGridViewBooks();
            ClearTextBoxes();
            labelLastAction.Text = "Usunięto książkę";
        }


        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku od edycji książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewBooks();
            ClearTextBoxes();
            labelLastAction.Text = "Edytowano książkę";
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku od czyszczenia TextBoxów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearTextBoxes_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            labelLastAction.Text = "Wyczyszczono pola";
        }

        /// <summary>
        /// Metoda wykonywana za każdym razem gdy użytkownik zmieni zaznaczenie wiersza w DataGridViewBook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            int rowCount = dataGridViewBooks.SelectedRows.Count;
            if(rowCount == 0 || rowCount > 1)
            {
                return;
            }

            DataGridViewRow row = dataGridViewBooks.SelectedRows[0];
            int id = int.Parse(row.Cells[0].Value.ToString());
            string  title = row.Cells[1].Value.ToString();
            int yearOfPublication = int.Parse(row.Cells[2].Value.ToString());
            int price = int.Parse(row.Cells[3].Value.ToString());
            string firstName = row.Cells[4].Value.ToString();
            string lastName = row.Cells[5].Value.ToString();
            string genre = row.Cells[6].Value.ToString();

            textBoxId.Text = id.ToString();
            textBoxBookTitle.Text = title;
            textBoxYearOfPublication.Text = yearOfPublication.ToString();
            textBoxPrice.Text = price.ToString();
            textBoxFirstName.Text = firstName;
            textBoxLastName.Text = lastName;
            textBoxGenre.Text = genre;
            labelLastAction.Text = "Wybrano książkę";
        }

        /// <summary>
        /// Metoda dostosowująca DataGridViewBooks - ustawianie widoczności kolumn i ich nazw
        /// </summary>
        private void CustomizeDataGridViewBooks()
        {
        }

        /// <summary>
        /// Metoda czyszcząca wszystkie TextBoxy w oknie głównym
        /// </summary>
        private void ClearTextBoxes()
        {
            textBoxId.Text = "";
            textBoxBookTitle.Text = "";
            textBoxYearOfPublication.Text = "";
            textBoxPrice.Text = "";
            textBoxGenre.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
        }

        /// <summary>
        /// Metoda odświeżająca dane w DataGridViewBooks
        /// </summary>
        private void RefreshDataGridViewBooks()
        {
            DataTable table = _repository.GetBooks();

            dataGridViewBooks.DataSource = table;
        }
    }
}
