using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawełGryglewiczLab1PracDom
{
    public partial class FormMainWindow : Form
    {
        /// <summary>
        /// Zmienna przechowująca ilość drewna
        /// </summary>
        int woodAmount;
        /// <summary>
        /// Zmienna przechowująca ilość kamienia
        /// </summary>
        int stoneAmount;
        /// <summary>
        /// Zmienna przechowująca ilość żelaza
        /// </summary>
        int ironAmount;
        /// <summary>
        /// Zmienna przechowująca ilość łuków
        /// </summary>
        int bowsAmmount;
        /// <summary>
        /// Zmienna przechowująca ilość pik
        /// </summary>
        int pikesAmmount;
        /// <summary>
        /// Zmienna przechowująca ilość mieczy
        /// </summary>
        int swordsAmmount;
        public FormMainWindow()
        {
            InitializeComponent();
        }

        private void FormMainWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
