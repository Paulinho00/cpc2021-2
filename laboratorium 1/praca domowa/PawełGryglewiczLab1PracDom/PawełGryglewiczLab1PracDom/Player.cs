using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawełGryglewiczLab1PracDom
{
    /// <summary>
    /// Klasa przechowująca stan konta i postepy gracza
    /// </summary> 
    class Player
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

        #region gettery i settery do pól klasy
        public int GoldAmount { get => goldAmount; set => goldAmount = value; }
        public int GoldAmount1 { get => goldAmount; set => goldAmount = value; }
        public int WoodAmount { get => woodAmount; set => woodAmount = value; }
        public int StoneAmount { get => stoneAmount; set => stoneAmount = value; }
        public int IronAmount { get => ironAmount; set => ironAmount = value; }
        public int BowsAmount { get => bowsAmount; set => bowsAmount = value; }
        public int PikesAmount { get => pikesAmount; set => pikesAmount = value; }
        public int SwordsAmount { get => swordsAmount; set => swordsAmount = value; }
        public int WoodcutterLevel { get => woodcutterLevel; set => woodcutterLevel = value; }
        public int StoneQuarryLevel { get => stoneQuarryLevel; set => stoneQuarryLevel = value; }
        public int MineLevel { get => mineLevel; set => mineLevel = value; }
        public int FletcherLevel { get => fletcherLevel; set => fletcherLevel = value; }
        public int PoleturnerLevel { get => poleturnerLevel; set => poleturnerLevel = value; }
        public int BlacksmithLevel { get => blacksmithLevel; set => blacksmithLevel = value; }
        public int WallLevel { get => wallLevel; set => wallLevel = value; }
        public int PrisonLevel { get => prisonLevel; set => prisonLevel = value; }
        #endregion

        /// <summary>
        /// Zwiększenie ilości drewna na koncie gracza
        /// </summary>
        public void IncreaseWoodAmount()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (woodcutterLevel)
            {
                case 1: woodAmount += 30; break;
                case 2: woodAmount += 40; break;
                case 3: woodAmount += 50; break;
            }
        }

        /// <summary>
        /// Zwiększenie ilości kamienia na koncie gracza
        /// </summary>
        public void IncreaseStoneAmount()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (stoneQuarryLevel)
            {
                case 1: stoneAmount += 10; break;
                case 2: stoneAmount += 20; break;
                case 3: stoneAmount += 30; break;
            }
        }

        /// <summary>
        /// Zwiększenie ilości żelaza na koncie gracza
        /// </summary>
        public void IncreaseIronAmount()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (mineLevel)
            {
                case 1: ironAmount += 3; break;
                case 2: ironAmount += 5; break;
                case 3: ironAmount += 8; break;
            }
        }

        /// <summary>
        /// Zwiększenie ilości łuków na koncie gracza
        /// </summary>
        public void IncreaseBowsAmount()
        {
            //Dodanie odpowiedniej ilości broni w zależności od poziomu ulepszenia
            switch (fletcherLevel)
            {
                case 0: bowsAmount += 0; break;
                case 1:
                    {
                        //Sprawdzenie czy gracz posiada wystarczającą liczbę drewna do utworzenia łuków
                        if (woodAmount >= 5)
                        {
                            //Odjęcie ilości drewna z magazynu, potrzebnej do wytworzenia łuków
                            woodAmount -= 5;
                            //Dodanie odpowiedniej ilości łuków
                            bowsAmount += 1;
                        }
                    }
                    break;
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
                    }
                    break;
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
                    }
                    break;
            }
        }

        /// <summary>
        /// Zwiększenie ilości pik na koncie gracza
        /// </summary>
        public void IncreasePikesAmount()
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
                    }
                    break;
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
                    }
                    break;
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
                    }
                    break;
            }
        }

        /// <summary>
        /// Zwiększenie ilości mieczy na koncie gracza
        /// </summary>
        public void IncreaseSwordsAmount()
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
                    }
                    break;
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
                    }
                    break;
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
                    }
                    break;
            }
        }

        public String WoodcutterUpgrade()
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
                //Zwrócenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś drwala";

            }
            else
            {
                //Utworzenie zmiennej przechowującej komunikat o błędzie przy ulepszaniu
                String message = "Za mało: ";
                //Sprawdzenie czy brakuje drewna
                if (woodAmount < 300)
                {
                    //Dodanie informacji o braku drewna
                    message = message + "drewna(brakuje:" + (300 - woodAmount) + ")";
                }
                //Sprawdzenie czy brakuje kamienia
                if (stoneAmount < 100)
                {
                    //Dodanie informacji o braku kamienia
                    message = message + " kamienia(brakuje:" + (100 - stoneAmount) + ")";
                }
                //Sprawdzenie czy brakuje żelaza
                if (ironAmount < 10)
                {
                    //Dodanie informacji o braku żelaza
                    message = message + " żelaza(brakuje:" + (10 - ironAmount) + ")";
                }
                return message;
            }
        }
    }
}
