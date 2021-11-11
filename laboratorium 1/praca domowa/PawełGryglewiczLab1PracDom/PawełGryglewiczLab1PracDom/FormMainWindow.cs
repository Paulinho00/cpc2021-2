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
                case 1:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia łuków
                        if(woodAmount >= 5)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia łuków
                            woodAmount -= 5;
                            //Dodanie odpowiedniej ilości łuków
                            bowsAmount += 1;
                        }
                    } break;
                case 2:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia łuków
                        if (woodAmount >= 10)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia łuków
                            woodAmount -= 10;
                            //Dodanie odpowiedniej ilości łuków
                            bowsAmount += 2;
                        }
                    } break;
                case 3:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia łuków
                        if (woodAmount >= 15)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia łuków
                            woodAmount -= 15;
                            //Dodanie odpowiedniej ilości łuków
                            bowsAmount += 3;
                        }
                    } break;
            }
            //Wyświetlenie nowej ilości drewna w oknie
            labelWoodAmount.Text = woodAmount.ToString();
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
                case 1:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia pik
                        if (woodAmount >= 5)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia pik
                             woodAmount -= 5;
                            //Dodanie odpowiedniej ilości pik
                            pikesAmount += 1;
                        }
                    } break;
                case 2:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia pik
                        if (woodAmount >= 10)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia pik
                            woodAmount -= 10;
                            //Dodanie odpowiedniej ilości pik
                            pikesAmount += 2;
                        }
                    } break;
                case 3:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia pik
                        if (woodAmount >= 15)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia pik
                            woodAmount -= 15;
                            //Dodanie odpowiedniej ilości pik
                            pikesAmount += 3;
                        }
                    } break;
            }
            //Wyświetlenie nowej ilości drewna w oknie
            labelWoodAmount.Text = woodAmount.ToString();
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
                case 1:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę żelaza do utworzenia mieczy
                        if (ironAmount >= 2)
                        {
                            //Odjęcie ilości żelaza z magazynu, potrzebnej do wytworzenia mieczy
                            ironAmount -= 2;
                            //Dodanie odpowiedniej ilości mieczy
                            swordsAmount += 1;
                        }
                    } break;
                case 2:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę żelaza do utworzenia mieczy
                        if (ironAmount >= 3)
                        {
                            //Odjęcie ilości żelaza z magazynu, potrzebnej do wytworzenia mieczy
                            ironAmount -= 3;
                            //Dodanie odpowiedniej ilości mieczy
                            swordsAmount += 2;
                        }
                    } break;
                case 3:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę żelaza do utworzenia mieczy
                        if (ironAmount >= 4)
                        {
                            //Odjęcie ilości żelaza z magazynu, potrzebnej do wytworzenia mieczy
                            ironAmount -= 4;
                            //Dodanie odpowiedniej ilości mieczy
                            swordsAmount += 3;
                        }
                    } break;
            }

            //Wyświetleniej nowej ilości żelaza w magazynie
            labelIronAmount.Text = ironAmount.ToString();
            //Wyświetlenie nowej ilości broni w oknie
            labelSwordsAmount.Text = swordsAmount.ToString();

        }

        /// <summary>
        /// Zwiększenie poziomu drwala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeWoodcutter_Click(object sender, EventArgs e)
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilośc surowców
            if (woodAmount >= 300 && stoneAmount >= 100 && ironAmount >= 10)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 300;
                stoneAmount -= 100;
                ironAmount -= 10;
                //Zwiększenie poziomu drwala
                woodcutterLevel += 1;
                //Wyświetlenie nowego poziomu w oknie
                labelWoodcutterLevel.Text = "Poziom: " + woodcutterLevel;
                //Wyświetlenie komunikatu o poprawnym ulepszeniu
                MessageBox.Show("Ulepszyłeś drwala");
            }
            else
            {
                //Utworzenie zmiennej przechowującej komunikat o błędzie przy ulepszaniu
                String message = "Za mało: ";
                //Sprawdzenie czy brakuje drewna
                if(woodAmount < 300)
                {
                    //Dodanie informacji o braku drewna
                    message = message + "drewna(brakuje:" + (300 - woodAmount) + ")";
                }
                //Sprawdzenie czy brakuje kamienia
                if(stoneAmount < 100)
                {
                    //Dodanie informacji o braku kamienia
                    message = message + " kamienia(brakuje:" + (100 - stoneAmount) + ")";
                }
                //Sprawdzenie czy brakuje żelaza
                if(ironAmount < 10)
                {
                    //Dodanie informacji o braku żelaza
                    message = message + " żelaza(brakuje:" + (10 - ironAmount) + ")";
                }
                //Wyświetlenie komunikatu błędu
                MessageBox.Show(message);
            }

            //Sprawdzenie czy budynek osiągnął maksymalny poziom
            if(woodcutterLevel == 3)
            {
                //Ukrycie przycisku ulepszającego
                buttonUpgradeWoodcutter.Visible = false;
            }
        }
    }
}
