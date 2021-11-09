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
    public partial class FromNewWindow : Form
    {
        /// <summary>
        /// Zmienna przechowująca wartość przekazaną z głównego okna
        /// </summary>
        string valueFromMainWindow;
        public FromNewWindow(string valueFromMainWindow)
        {
            InitializeComponent();
            //Przypisanie przekazanej wartości do zmiennej 'valueFromMainWindow'
            this.valueFromMainWindow = valueFromMainWindow;
        }

        private void FormNewWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowValue_Click(object sender, EventArgs e)
        {
            label.Text = valueFromMainWindow;
        }

        /// <summary>
        /// Metoda wywoływana w momencie próby zamknięcie okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrommNewWindow_FromClosing(object sender, FormClosingEventArgs e)
        {
            //Wyświetlenie zapytania
            var result = MessageBox.Show("Czy napewno chcesz to zrobić", "Uwaga", MessageBoxButtons.YesNo);
            //Warunek sprawdzający jaka odpowiedź została wybrana
            if(result == DialogResult.No)
            {
                //Anulowanie zamykania okna
                e.Cancel = true;
            }
        }
    }
}
