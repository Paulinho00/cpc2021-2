using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawełGryglewiczLab1
{
    public partial class PawełGryglewiczLab1 : Form
    {
        /// <summary>
        /// Zmienna dla pola textBoxAdd i textBoxMultiplication
        /// </summary>
        int number = 1;

        /// <summary>
        /// Zmienna dla timera timerCounter
        /// </summary>
        int counter = 1;
        /// <summary>
        /// Zmienna przechowująca referencję do drugie okna
        /// </summary>
        private FromNewWindow formNewWindow;
        public PawełGryglewiczLab1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Zmieni tekst z pola textBoxAdd na wartość liczbową
            number = Int32.Parse(textBoxAdd.Text);
            // Zwiększenie zmiennej 'numer' o 3
            number += 3;
            //Zamiana wartości 'numer' na napis
            textBoxAdd.Text = number.ToString();
            //Warunek sprawdzający czy przekroczono wartość 10
            if (number > 10)
            {

                MessageBox.Show("Przekroczono wartość 10");
            }
        }

        private void textBoxAdd_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Przycisk zmieniający kolor przyciska
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonColor_Click(object sender, EventArgs e)
        {
            //Zmienianie koloru przycisku
            buttonColor.BackColor = Color.Cyan;
        }

        /// <summary>
        /// Przycisk odpowiadający za mnożenie wartości liczbowej w polu tekstowym
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            //Zmieni tekst z pola tekstowego na wartość liczbową
            number = Int32.Parse(textBoxMultiplication.Text);
            // Pomnożenie wartości 'numer' przez 5
            number *= 5;
            //Zamiana wartości 'numer' na napis
            textBoxMultiplication.Text = number.ToString();
        }

        /// <summary>
        /// Przycisk odpowiadający za start timera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void buttonStart_Click(object sender, EventArgs e)
        {
            // Uruchomienie timera
            timerCounter.Start();
        }

        /// <summary>
        /// Metoda wywoływana przez wątek timera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCounter_Tick(object sender, EventArgs e)
        {
            // Zwiększenie wartości zmiennej
            counter++;

            //Warunek sprawdzający czy zmienna 'counter' osiągnęła wartość 5
            if(counter == 5)
            {
                //Zmiana tła przycisku na czerwony
                buttonAdd.BackColor = Color.Red;
            }
            //Warunek sprawdzający czy zmienna 'counter' osiągnęła wartość 10
            if (counter == 10)
            {
                // Wyświetlenie komunikatu
                MessageBox.Show("Wartość wynosi 5");
            }

        }

        /// <summary>
        /// Przycisk otwierający nowe okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewWindow_Click(object sender, EventArgs e)
        {
            // Utworzenie nowego obiektu klasy FromNewWindow
            formNewWindow = new FromNewWindow("Paweł Gryglewicz");
            formNewWindow.Show();
        }
    }
}
