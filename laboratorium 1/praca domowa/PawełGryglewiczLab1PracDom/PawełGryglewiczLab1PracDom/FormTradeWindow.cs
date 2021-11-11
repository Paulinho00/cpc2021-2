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
    public partial class FormTradeWindow : Form
    {
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu gracza ze stanem konta
        /// </summary>
        private Player player;
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu Timera z głównego okna gry
        /// </summary>
        private Timer timerFromMainWindow;
        public FormTradeWindow(Player player, Timer timer)
        {
            InitializeComponent();
            //Przypisanie referencji do obiektu gracza
            this.player = player;
            //Przypisanie referencji do obiektu Timera
            timerFromMainWindow = timer;
            timerFromMainWindow.Stop();
        }

    }
}
