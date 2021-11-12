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
    public class Player
    {
        /// <summary>
        /// Zmienna przechowująca ilośc złota
        /// </summary>
        int goldAmount = 10000;
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
        int bowsAmount = 60;
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
        /// <summary>
        /// Zmienna przechowująca liczbę posiadanych łuczników
        /// </summary>
        int archers = 0;
        /// <summary>
        /// Zmienna przechowująca liczbę posiadanych pikinierów
        /// </summary>
        int pikemen = 0;
        /// <summary>
        /// Zmienna przechowująca liczbę posiadanych mieczników
        /// </summary>
        int swordsmen = 0;

        #region gettery i settery do pól klasy
        public int GoldAmount { get => goldAmount; set => goldAmount = value; }
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
        public int Archers { get => archers; set => archers = value; }
        public int Pikemen { get => pikemen; set => pikemen = value; }
        public int Swordsmen { get => swordsmen; set => swordsmen = value; }
        #endregion

        /// <summary>
        /// Zwiększenie ilości drewna na koncie gracza
        /// </summary>
        public void IncreaseWoodAmount()
        {
            //Dodanie odpowiedniej ilości surowca w zależności od poziomu ulepszenia
            switch (woodcutterLevel)
            {
                case 1: woodAmount += 35; break;
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
                case 1: ironAmount += 4; break;
                case 2: ironAmount += 6; break;
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

        /// <summary>
        /// Generowanie komunikatu błędu w zależności od podanego kosztu ulepszenia
        /// </summary>
        /// <param name="wood">koszt ulepszenia w drewnie</param>
        /// <param name="stone">koszt ulepszenia w kamieniu</param>
        /// <param name="iron">koszt ulepszenia w żelazie</param>
        /// <returns></returns>
        string ErrorMessageCreator(int wood, int stone, int iron)
        {
            //Utworzenie zmiennej przechowującej komunikat o błędzie przy ulepszaniu
            String message = "Za mało: ";
            //Sprawdzenie czy brakuje drewna
            if (woodAmount < wood)
            {
                //Dodanie informacji o braku drewna
                message = message + "drewna(brakuje:" + (wood - woodAmount) + ")";
            }
            //Sprawdzenie czy brakuje kamienia
            if (stoneAmount < stone)
            {
                //Dodanie informacji o braku kamienia
                message = message + " kamienia(brakuje:" + (stone - stoneAmount) + ")";
            }
            //Sprawdzenie czy brakuje żelaza
            if (ironAmount < iron)
            {
                //Dodanie informacji o braku żelaza
                message = message + " żelaza(brakuje:" + (iron - ironAmount) + ")";
            }
            //Zwrócenie komunikatu o błędzie
            return message;
        }

        /// <summary>
        /// Zwiększenie poziomu drwala i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String WoodcutterUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 300 && stoneAmount >= 100 && ironAmount >= 10)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 300;
                stoneAmount -= 100;
                ironAmount -= 10;
                //Zwiększenie poziomu drwala
                woodcutterLevel++;
                //Zwrócenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś drwala";

            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(300, 100, 10);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu kamieniołomu i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String StoneQuarryUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 500 && stoneAmount >= 50 && ironAmount >= 30)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 500;
                stoneAmount -= 50;
                ironAmount -= 30;
                //Zwiększenie poziomu kamieniołomu
                stoneQuarryLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś kamieniołom";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(500, 50, 30);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu kopalni i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String MineUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 700 && stoneAmount >= 80 && ironAmount >= 10)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 700;
                stoneAmount -= 80;
                ironAmount -= 10;
                //Zwiększenie poziomu kopalni
                mineLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś kopalnię";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(700, 80, 10);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu łuczarza i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String FletcherUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 700 && stoneAmount >= 120 && ironAmount >= 50)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 700;
                stoneAmount -= 120;
                ironAmount -= 50;
                //Zwiększenie poziomu łuczarza
                fletcherLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś łuczarza";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(700, 120, 50);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu tokarza i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String PoleturnerUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 800 && stoneAmount >= 140 && ironAmount >= 60)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 800;
                stoneAmount -= 140;
                ironAmount -= 60;
                //Zwiększenie poziomu tokarza
                poleturnerLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś tokarza";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(800, 140, 60);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu kowala i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String BlacksmithUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 1000 && stoneAmount >= 300 && ironAmount >= 100)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 1000;
                stoneAmount -= 300;
                ironAmount -= 100;
                //Zwiększenie poziomu kowala
                blacksmithLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś kowala";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(1000, 300, 100);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu murów i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String WallUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 500 && stoneAmount >= 1000 && ironAmount >= 100)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 500;
                stoneAmount -= 1000;
                ironAmount -= 100;
                //Zwiększenie poziomu murów
                wallLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś mur";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(500, 1000, 100);
            }
        }

        /// <summary>
        /// Zwiększenie poziomu więzienia i odjęcie surowców potrzebnych do ulepszenia
        /// </summary>
        /// <returns></returns>
        public String PrisonUpgrade()
        {
            //Sprawdzenie czy gracz posiada potrzebną do ulepszenia, ilość surowców
            if (woodAmount >= 250 && stoneAmount >= 750 && ironAmount >= 300)
            {
                //Odjęcie surowców z konta gracza
                woodAmount -= 250;
                stoneAmount -= 750;
                ironAmount -= 300;
                //Zwiększenie poziomu więzienia
                prisonLevel++;
                //Zwrocenie komunikatu o udanym ulepszeniu
                return "Ulepszyłeś więzienie";
            }
            else
            {
                //Wywołanie metody generującej komunikat błędu i zwrócenie jej wyniku
                return ErrorMessageCreator(250, 750, 300);
            }
        }
        
        /// <summary>
        /// Odjęcie z konta gracza kosztów rekrutacji i dodanie odpowiedniej liczby wojska
        /// </summary>
        /// <param name="archers">liczba zrekrutowanych łuczników</param>
        /// <param name="pikemen">liczba zrekrutowanych pikinierów</param>
        /// <param name="swordsmen">liczba zrekrutowanych mieczników</param>
        public void Recruitment(int archers, int pikemen, int swordsmen)
        {
            //Odjęcie złota z konta gracza, wydanego podczas rekrutacji
            goldAmount = goldAmount - (archers * 30) - (pikemen * 50) - (swordsmen * 100);
            //Odjęcie łuków z konta gracza, wykorzystanych podczas rekrutacji łuczników
            bowsAmount -= archers;
            //Odjęcie pik z konta gracza, wykorzystanych podczas rekrutacji pikinierów
            pikesAmount -= pikemen;
            //Odjęcie mieczy z konta gracza, wykorzystanych podczas rekrutacji mieczników
            swordsAmount -= swordsmen;
            //Dodanie zrekrutowanych łuczników do konta gracza
            this.archers += archers;
            //Dodanie zrekrutowanych pikinierów do konta gracza
            this.pikemen += pikemen;
            //Dodanie zrekrutowanych mieczników do konta gracza
            this.swordsmen += swordsmen;

        }

        /// <summary>
        /// Metoda wymieniająca drewno na złoto lub złoto na drewno w zależności od parametrów
        /// </summary>
        /// <param name="tradedResources">ilość drewna do wymiany</param>
        /// <param name="goldValue">koszt/zysk wymiany w złocie</param>
        /// <param name="isBuying">parametr określający czy wykonano kupno, czy sprzedaż</param>
        public void TradeWood(int tradedResources, int goldValue, Boolean isBuying )
        {
            //Sprawdzenie czy dokonano kupna
            if(isBuying)
            {
                //Dodanie odpowiedniej kupionej ilości drewna do konta
                woodAmount += tradedResources;
                //Odjęcie kosztu zakupu w złocie z konta
                goldAmount -= goldValue;
            }
            else
            {
                //Odjęcie odpowiedniej sprzedanej ilości drewna z konta
                woodAmount -= tradedResources;
                //Dodanie zysku ze sprzedaży w złocie do konta
                goldAmount += goldValue;
            }
        }

        /// <summary>
        /// Metoda wymieniająca kamień na złoto lub złoto na kamień w zależności od parametrów
        /// </summary>
        /// <param name="tradedResources">ilość kamienia do wymiany</param>
        /// <param name="goldValue">koszt/zysk wymiany w złocie</param>
        /// <param name="isBuying">parametr określający czy wykonano kupno, czy sprzedaż</param>
        public void TradeStone(int tradedResources, int goldValue, Boolean isBuying)
        {
            //Sprawdzenie czy dokonano kupna
            if (isBuying)
            {
                //Dodanie odpowiedniej kupionej ilości kamienia do konta
                stoneAmount += tradedResources;
                //Odjęcie kosztu zakupu w złocie z konta
                goldAmount -= goldValue;
            }
            else
            {
                //Odjęcie odpowiedniej sprzedanej ilości kamienia z konta
                stoneAmount -= tradedResources;
                //Dodanie zysku ze sprzedaży w złocie do konta
                goldAmount += goldValue;
            }
        }

        /// <summary>
        /// Metoda wymieniająca żelazo na złoto lub złoto na żelazo w zależności od parametrów
        /// </summary>
        /// <param name="tradedResources">ilość żelaza do wymiany</param>
        /// <param name="goldValue">koszt/zysk wymiany w złocie</param>
        /// <param name="isBuying">parametr określający czy wykonano kupno, czy sprzedaż</param>
        public void TradeIron(int tradedResources, int goldValue, Boolean isBuying)
        {
            //Sprawdzenie czy dokonano kupna
            if (isBuying)
            {
                //Dodanie odpowiedniej kupionej ilości żelaza do konta
                ironAmount += tradedResources;
                //Odjęcie kosztu zakupu w złocie z konta
                goldAmount -= goldValue;
            }
            else
            {
                //Odjęcie odpowiedniej sprzedanej ilości żelaza z konta
                ironAmount -= tradedResources;
                //Dodanie zysku ze sprzedaży w złocie do konta
                goldAmount += goldValue;
            }
        }

        /// <summary>
        /// Metoda wymieniająca łuki na złoto lub złoto na łuki w zależności od parametrów
        /// </summary>
        /// <param name="tradedResources">ilość łuków do wymiany</param>
        /// <param name="goldValue">koszt/zysk wymiany w złocie</param>
        /// <param name="isBuying">parametr określający czy wykonano kupno, czy sprzedaż</param>
        public void TradeBows(int tradedResources, int goldValue, Boolean isBuying)
        {
            //Sprawdzenie czy dokonano kupna
            if (isBuying)
            {
                //Dodanie odpowiedniej kupionej ilości łuków do konta
                bowsAmount += tradedResources;
                //Odjęcie kosztu zakupu w złocie z konta
                goldAmount -= goldValue;
            }
            else
            {
                //Odjęcie odpowiedniej sprzedanej ilości łuków z konta
                bowsAmount -= tradedResources;
                //Dodanie zysku ze sprzedaży w złocie do konta
                goldAmount += goldValue;
            }
        }

        /// <summary>
        /// Metoda wymieniająca piki na złoto lub złoto na piki w zależności od parametrów
        /// </summary>
        /// <param name="tradedResources">ilość pik do wymiany</param>
        /// <param name="goldValue">koszt/zysk wymiany w złocie</param>
        /// <param name="isBuying">parametr określający czy wykonano kupno, czy sprzedaż</param>
        public void TradePikes(int tradedResources, int goldValue, Boolean isBuying)
        {
            //Sprawdzenie czy dokonano kupna
            if (isBuying)
            {
                //Dodanie odpowiedniej kupionej ilości pik do konta
                pikesAmount += tradedResources;
                //Odjęcie kosztu zakupu w złocie z konta
                goldAmount -= goldValue;
            }
            else
            {
                //Odjęcie odpowiedniej sprzedanej ilości pik z konta
                pikesAmount -= tradedResources;
                //Dodanie zysku ze sprzedaży w złocie do konta
                goldAmount += goldValue;
            }
        }

        /// <summary>
        /// Metoda wymieniająca miecze na złoto lub złoto na miecze w zależności od parametrów
        /// </summary>
        /// <param name="tradedResources">ilość mieczy do wymiany</param>
        /// <param name="goldValue">koszt/zysk wymiany w złocie</param>
        /// <param name="isBuying">parametr określający czy wykonano kupno, czy sprzedaż</param>
        public void TradeSwords(int tradedResources, int goldValue, Boolean isBuying)
        {
            //Sprawdzenie czy dokonano kupna
            if (isBuying)
            {
                //Dodanie odpowiedniej kupionej ilości mieczy do konta
                swordsAmount += tradedResources;
                //Odjęcie kosztu zakupu w złocie z konta
                goldAmount -= goldValue;
            }
            else
            {
                //Odjęcie odpowiedniej sprzedanej ilości mieczy z konta
                swordsAmount -= tradedResources;
                //Dodanie zysku ze sprzedaży w złocie do konta
                goldAmount += goldValue;
            }
        }

    }
}
