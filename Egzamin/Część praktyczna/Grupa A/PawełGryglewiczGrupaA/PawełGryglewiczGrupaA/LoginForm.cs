using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawełGryglewiczGrupaA
{
    public partial class LoginForm : Form
    {
        private string CorrectLogin { get; set; }
        private string CorrectPassword { get; set; }
        private int NumberOfLogErrors { get; set; }

        private DatabaseHandler _databaseHandler = new DatabaseHandler();

        public LoginForm()
        {
            InitializeComponent();
            CorrectLogin = "Kredek";
            CorrectPassword = "kredek123";
        }

        /// <summary>
        /// Metoda wykonująca logowanie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Odczyt loginu i hasła z textboxa
            string loginInputValue = LoginTextBox.Text;
            string passwordInputValue = PasswordTextBox.Text;

            //Sprawdzenie czy wprowadzone hasło i login są poprawne
            if (loginInputValue.Equals(CorrectLogin) && passwordInputValue.Equals(CorrectPassword))
            {
                //Wyświetlenie komunikatu o zalogowaniu
                LoginLabel.Visible = true;
            }
            else
            {
                LoginLabel.Visible = false;
                NumberOfLogErrors++;
            }

            //Sprawdzenie czy liczba prób logowania jest równa 3
            if(NumberOfLogErrors == 3)
            {
                //Ukrycie textboxów
                LoginTextBox.Visible = false;
                PasswordTextBox.Visible = false;
                //Wyświetlenie komunikatu błędu
                ErrorLabel.Visible = true;
            }

        }

        /// <summary>
        /// Metoda startująca timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerInitButton_Click(object sender, EventArgs e)
        {
            buttonTimer.Start();
        }

        /// <summary>
        /// Metoda przesuwająca przycisk co jeden tick timera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTimer_Tick(object sender, EventArgs e)
        {
            //Obliczanie nowego położenia przycisku
            int x = MovingButton.Location.X - 3;
            int y = MovingButton.Location.Y + 5;
            //Zmiana lokalizacji przycisku
            MovingButton.Location = new Point(x, y);
        }

        private void showRecordsButton_Click(object sender, EventArgs e)
        {
            DataFromDBDataGridView.DataSource = _databaseHandler.GetRecords();
        }
    }
}
