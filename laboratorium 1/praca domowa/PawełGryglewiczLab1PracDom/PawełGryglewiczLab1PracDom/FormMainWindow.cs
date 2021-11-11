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
        private Player player;
        
        public FormMainWindow()
        {
            InitializeComponent();
            player = new Player();
        }

        /// <summary>
        /// Metoda wywoływana przez wątek timera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCounter_Tick(object sender, EventArgs e)
        {
            #region wywołanie metod odpowiedzialnych za zwiększenie ilości broni i surowców w każdej "turze"
            //Wywołanie metody zwiększającej ilości drewna w "magazynie"
            WoodIncrease();
            //Wywołanie metody zwiększającej ilości kamienia w "magazynie"
            StoneIncrease();
            //Wywołanie metody zwiększającej ilości żelaza w "magazynie"
            ironIncrease();
            //Wywołanie metody zwiększającej ilości łuków w "magazynie"
            bowsIncrease();
            //Wywołanie metody zwiększającej ilości pik w "magazynie"
            pikesIncrease();
            //Wywołanie metody zwiększającej ilości mieczy w "magazynie"
            swordsIncrease();
            #endregion
        }

        /// <summary>
        /// Metoda zwiększająca ilość drewna w "magazynie", zgodnie z poziomem ulepszenia drwala
        /// </summary>
        private void WoodIncrease()
        {
            //Wywołanie metody zwiększającej stan konta
            player.IncreaseWoodAmount();
            //Wyświetlenie nowej ilości surowca w oknie
            labelWoodAmount.Text = player.WoodAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość kamienia w "magazynie", zgodnie z poziomem ulepszenia kamieniołomu
        /// </summary>
        private void StoneIncrease()
        {
            //Wywołanie metody zwiększającej stan konta
            player.IncreaseStoneAmount();
            //Wyświetlenie nowej ilości surowca w oknie
            labelStoneAmount.Text = player.StoneAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość żelaza w "magazynie", zgodnie z poziomem ulepszenia kopalni
        /// </summary>
        private void ironIncrease()
        {
            //Wywołanie metody zwiększającej stan konta
            player.IncreaseIronAmount();
            //Wyświetlenie nowej ilości surowca w oknie
            labelIronAmount.Text = player.IronAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość łuków w "zbrojowni", zgodnie z poziomem ulepszenia łuczarza
        /// </summary>
        private void bowsIncrease()
        {
            //Wywołanie metody zwiększającej stan konta
            player.IncreaseBowsAmount();
            //Wyświetlenie nowej ilości drewna w oknie
            labelWoodAmount.Text = player.WoodAmount.ToString();
            //Wyświetlenie nowej ilości broni w oknie
            labelBowsAmount.Text = player.BowsAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość włóczni w "zbrojowni", zgodnie z poziomem ulepszenia tokarza
        /// </summary>
        private void pikesIncrease()
        {
            //Wywołanie metody zwiększającej stan konta
            player.IncreasePikesAmount();
            //Wyświetlenie nowej ilości drewna w oknie
            labelWoodAmount.Text = player.WoodAmount.ToString();
            //Wyświetlenie nowej ilości broni w oknie
            labelPikesAmount.Text = player.PikesAmount.ToString();

        }

        /// <summary>
        /// Metoda zwiększająca ilość mieczy w "zbrojowni", zgodnie z poziomem ulepszenia kowala
        /// </summary>
        private void swordsIncrease()
        {
            //Wywołanie metody zwiększającej stan konta
            player.IncreaseSwordsAmount();
            //Wyświetleniej nowej ilości żelaza w magazynie
            labelIronAmount.Text = player.IronAmount.ToString();
            //Wyświetlenie nowej ilości broni w oknie
            labelSwordsAmount.Text = player.SwordsAmount.ToString();

        }

        /// <summary>
        /// Zwiększenie poziomu drwala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeWoodcutter_Click(object sender, EventArgs e)
        {
            String message = player.WoodcutterUpgrade();

            if (message.Equals("Ulepszyłeś drwala")) {
                //Wyświetlenie nowego poziomu w oknie
                labelWoodcutterLevel.Text = "Poziom: " + player.WoodcutterLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show("Ulepszyłeś drwala");
            }
            else 
            { 
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if(player.WoodcutterLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeWoodcutter.Visible = false;
            }
        }
    }
}
