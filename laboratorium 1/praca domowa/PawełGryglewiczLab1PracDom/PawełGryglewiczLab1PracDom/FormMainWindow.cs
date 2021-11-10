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
        /// Zmienna przechowująca ilośc złota
        /// </summary>
        int goldAmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość drewna
        /// </summary>
        int woodAmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość kamienia
        /// </summary>
        int stoneAmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość żelaza
        /// </summary>
        int ironAmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość łuków
        /// </summary>
        int bowsAmmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość pik
        /// </summary>
        int pikesAmmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość mieczy
        /// </summary>
        int swordsAmmount = 0;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania drwala
        /// </summary>
        int woodcutterLevel = 1;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania kamieniołomu
        /// </summary>
        int stoneQuarryLevel = 1;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania kopalni
        /// </summary>
        int mineLevel = 1;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania łuczarza
        /// </summary>
        int fletcherLevel = 0;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania tokarza
        /// </summary>
        int poleturnerLevel = 0;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania kowala
        /// </summary>
        int blacksmithLevel = 0;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania muru
        /// </summary>
        int wallLevel = 0;
        /// <summary>
        /// Zmienna przechowująca poziom rozbudowania więzienia
        /// </summary>
        int prisonLevel = 0;
        public FormMainWindow()
        {
            InitializeComponent();
        }


    }
}
