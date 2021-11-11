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
        /// Zmienna przechowująca referencję do obiektu gracza ze stanem konta
        /// </summary>
        private Player player;
        /// <summary>
        /// Zmienna przechowująca informację czy gra jest zatrzymana
        /// </summary>
        private Boolean isStoped = false;

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
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.WoodcutterUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś drwala")) {
                //Wyświetlenie nowego poziomu w oknie
                labelWoodcutterLevel.Text = "Poziom: " + player.WoodcutterLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
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

        /// <summary>
        /// Zwiększenie poziomu kamieniołomu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeStoneQuarry_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.StoneQuarryUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś kamieniołom")){
                //Wyświetlenie nowego poziomu w oknie
                labelStoneQuarryLevel.Text = "Poziom: " + player.StoneQuarryLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.StoneQuarryLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeStoneQuarry.Visible = false;
            }
        }

        /// <summary>
        /// Zwiększenie poziomu kopalni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeMine_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.MineUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś kopalnię"))
            {
                //Wyświetlenie nowego poziomu w oknie
                labelMineLevel.Text = "Poziom: " + player.MineLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.MineLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeMine.Visible = false;
            }
        }

        /// <summary>
        /// Zwiększenie poziomu łuczarza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeFletcher_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.FletcherUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś łuczarza"))
            {
                //Wyświetlenie nowego poziomu w oknie
                labelFletcherLevel.Text = "Poziom: " + player.FletcherLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.FletcherLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeFletcher.Visible = false;
            }
        }

        /// <summary>
        /// Zwiększenie poziomu tokarza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradePoleturner_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.PoleturnerUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś tokarza"))
            {
                //Wyświetlenie nowego poziomu w oknie
                labelPoleturnerLevel.Text = "Poziom: " + player.PoleturnerLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.PoleturnerLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradePoleturner.Visible = false;
            }
        }

        /// <summary>
        /// Zwiększenie poziomu kowala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeBlacksmith_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.BlacksmithUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś kowala"))
            {
                //Wyświetlenie nowego poziomu w oknie
                labelBlacksmithLevel.Text = "Poziom: " + player.BlacksmithLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.BlacksmithLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeBlacksmith.Visible = false;
            }
        }

        /// <summary>
        /// Zwiększenie poziomu muru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeWall_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.WallUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś mur"))
            {
                //Wyświetlenie nowego poziomu w oknie
                labelWallLevel.Text = "Poziom: " + player.WallLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.WallLevel == 5)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeWall.Visible = false;
            }
        }

        /// <summary>
        /// Zwiększenie poziomu więzienia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradePrison_Click(object sender, EventArgs e)
        {
            //Wywołanie metody ulepszającej i zapisanie zwrotnego komunikatu
            String message = player.PrisonUpgrade();

            //Sprawdzenie czy ulepszenie powiodło się
            if (message.Equals("Ulepszyłeś więzienie"))
            {
                //Wyświetlenie nowego poziomu w oknie
                labelPrisonLevel.Text = "Poziom: " + player.PrisonLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show(message);
            }
            else
            {
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if (player.PrisonLevel == 5)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradePrison.Visible = false;
            }
        }

        /// <summary>
        /// Zatrzymanie gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPause_Click(object sender, EventArgs e)
        {
            //Sprawdzenie czy gra jest zatrzymana
            if (isStoped)
            {
                //Wystartowanie timera
                timerCounter.Start();
                isStoped = false;
                //Zmiana tesktu przycisku pauzy
                buttonPause.Text = "Pauza";
            }
            else
            {
                //Zatrzymanie gry
                timerCounter.Stop();
                isStoped = true;
                //Zmiana tekstu przycisku pauzy
                buttonPause.Text = "Odpauzuj";
            }
        }

        /// <summary>
        /// Otwarcie okna rekrutacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenRecruitmentWindow_Click(object sender, EventArgs e)
        {
            //Zmienna przechowująca referencję do obiektu okna rekrutacji
            FormRecruitmentWindow formRecruitmentWindow = new FormRecruitmentWindow(player, timerCounter, this);
            //Wyświetlenie okna rekrutacji
            formRecruitmentWindow.Show();
        }

        /// <summary>
        /// Aktualizacja wszystkich wartości liczbowych surowców, broni, wojska w oknie
        /// </summary>
        public void ValuesUpdate()
        {
            //Wyświetlenie aktualnej posiadnej ilości złota
            labelGoldAmount.Text = player.GoldAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby drewna
            labelWoodAmount.Text = player.WoodAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby kamienia
            labelStoneAmount.Text = player.StoneAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby żelaza
            labelIronAmount.Text = player.IronAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby łuków
            labelBowsAmount.Text = player.BowsAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby pik
            labelPikemen.Text = player.PikesAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby mieczy
            labelSwordsAmount.Text = player.SwordsAmount.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby łuczników
            labelArchersNumber.Text = player.Archers.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby pikinierów
            labelPikemenNumber.Text = player.Pikemen.ToString();
            //Wyświetlenie aktualnej posiadanej przez gracza liczby mieczników
            labelSwordsmenNumber.Text = player.Swordsmen.ToString();
        }

    }
}
