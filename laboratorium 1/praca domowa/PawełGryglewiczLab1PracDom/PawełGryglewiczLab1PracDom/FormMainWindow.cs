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
        int bowsAmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość pik
        /// </summary>
        int pikesAmount = 0;
        /// <summary>
        /// Zmienna przechowująca ilość mieczy
        /// </summary>
        int swordsAmount = 0;
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

        /// <summary>
        /// Metoda wywoływana przez wątek timera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCounter_Tick(object sender, EventArgs e)
        {
            #region wywołanie metod odpowiedzialnych za zwiększenie ilości broni i surowców w każdej "turze"
            //Wywołanie metody zwiększającej ilości drewna w "magazynie"
            woodIncrease();
            //Wywołanie metody zwiększającej ilości kamienia w "magazynie"
            stoneIncrease();
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
        private void woodIncrease()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (woodcutterLevel)
            {
                case 1: woodAmount += 30; break;
                case 2: woodAmount += 40; break;
                case 3: woodAmount += 50; break;
            }
            //Wyświetlenie nowej ilości surowca w oknie
            labelWoodAmount.Text = woodAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość kamienia w "magazynie", zgodnie z poziomem ulepszenia kamieniołomu
        /// </summary>
        private void stoneIncrease()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (stoneQuarryLevel)
            {
                case 1: stoneAmount += 10; break;
                case 2: stoneAmount += 20; break;
                case 3: stoneAmount += 30; break;
            }
            //Wyświetlenie nowej ilości surowca w oknie
            labelStoneAmount.Text = stoneAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość żelaza w "magazynie", zgodnie z poziomem ulepszenia kopalni
        /// </summary>
        private void ironIncrease()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (mineLevel)
            {
                case 1: ironAmount += 3; break;
                case 2: ironAmount += 5; break;
                case 3: ironAmount += 8; break;
            }
            //Wyświetlenie nowej ilości surowca w oknie
            labelIronAmount.Text = ironAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość łuków w "zbrojowni", zgodnie z poziomem ulepszenia łuczarza
        /// </summary>
        private void bowsIncrease()
        {
            //Dodanie odpowiedniej ilości broni w zależności od poziomu ulepszenia
            switch (fletcherLevel)
            {
                case 0: bowsAmount += 0; break;
                case 1: bowsAmount += 1; break;
                case 2: bowsAmount += 2; break;
                case 3: bowsAmount += 3; break;
            }
            //Wyświetlenie nowej ilości broni w oknie
            labelBowsAmount.Text = bowsAmount.ToString();
        }

        /// <summary>
        /// Metoda zwiększająca ilość włóczni w "zbrojowni", zgodnie z poziomem ulepszenia tokarza
        /// </summary>
        private void pikesIncrease()
        {
            //Dodanie odpowiedniej ilości broni w zależności od poziomu ulepszenia
            switch (poleturnerLevel)
            {
                case 0: pikesAmount += 0; break;
                case 1: pikesAmount += 1; break;
                case 2: pikesAmount += 2; break;
                case 3: pikesAmount += 3; break;
            }
            //Wyświetlenie nowej ilości broni w oknie
            labelPikesAmount.Text = pikesAmount.ToString();

        }

        /// <summary>
        /// Metoda zwiększająca ilość mieczy w "zbrojowni", zgodnie z poziomem ulepszenia kowala
        /// </summary>
        private void swordsIncrease()
        {
            //Dodanie odpowiedniej ilości broni w zależności od poziomu ulepszenia
            switch (blacksmithLevel)
            {
                case 0: swordsAmount += 0; break;
                case 1: pikesAmount += 1;  break;
                case 2: pikesAmount += 2; break;
                case 3: pikesAmount += 3; break;
            }
            //Wyświetlenie nowej ilości broni w oknie
            labelPikesAmount.Text = pikesAmount.ToString();

        }
    }
}
