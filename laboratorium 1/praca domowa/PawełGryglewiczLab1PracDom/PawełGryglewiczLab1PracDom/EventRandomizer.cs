using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawełGryglewiczLab1PracDom
{
    /// <summary>
    /// Klasa zarządzająca eventami w grze oraz ich losowaniem
    /// </summary>
    class EventRandomizer
    {
        /// <summary>
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o zawaleniu się łuczarza
        /// </summary>
        private int fletcherCollapsedEventProbability;
        /// <summary>
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o zawaleniu się tokarza
        /// </summary>
        private int poleturnerCollapsedEventProbability;
        /// <summary>
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o zawaleniu się kowala
        /// </summary>
        private int blacksmithCollapsedEventProbability;
        /// <summary>
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o ataku na gracza
        /// </summary>
        private int attackEventProbability;
        /// <summary>
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o kradzieży ze składu
        /// </summary>
        private int thiefEventProbability;
        /// <summary>
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o dezercji żołnierzy
        /// </summary>
        private int desertionEventProbability;
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu gracza ze stanem konta
        /// </summary>
        private Player player;
        /// <summary>
        /// Zmienna przechowująca referencję do głównego okna
        /// </summary>
        private FormMainWindow mainWindow;

        public EventRandomizer(Player player, FormMainWindow formMainWindow)
        {
            //Przypisanie referencji do obiektu gracza
            this.player = player;
            //Przypisanie referencji do obiektu głównego okna
            mainWindow = formMainWindow;
        }

        /// <summary>
        /// Metodą losoująca event
        /// </summary>
        public void randomEvent()
        {
            //Wywołanie metody sprawdzającej i zmieniającej prawdopodobieństwo eventów
            EventsProbabilityChecker();
            //Utworzenie zmiennej przechowującej górny zakres losowania
            int range = fletcherCollapsedEventProbability + poleturnerCollapsedEventProbability + blacksmithCollapsedEventProbability + attackEventProbability + thiefEventProbability + desertionEventProbability+80;
            //Utworzenie obiektu Random
            Random random = new Random();
            //Wylosowanie losowej liczby
            int randomNumber = random.Next(1, range + 1);
            //Utworzenie zmiennej przechowującej dolny zakres przedziału liczbowego, w którym mieści się dany event
            int intervalBeginning = 0;

            //Sprawdzenie czy liczba mieści w przedziale eventu i wywołanie go jeśli mieści się
            if (randomNumber <= fletcherCollapsedEventProbability) FletcherCollapseEvent();
            //Zwiększenie dolnego zakresu przedziału liczbowego, do kolejengo eventu
            intervalBeginning += fletcherCollapsedEventProbability;

            //Sprawdzenie czy liczba mieści w przedziale eventu i wywołanie go jeśli mieści się
            if (randomNumber > intervalBeginning && randomNumber <= (intervalBeginning + poleturnerCollapsedEventProbability)) PoleturnerCollapsedEvent();
            //Zwiększenie dolnego zakresu przedziału liczbowego, do kolejengo eventu
            intervalBeginning += poleturnerCollapsedEventProbability;

            //Sprawdzenie czy liczba mieści w przedziale eventu i wywołanie go jeśli mieści się
            if (randomNumber > intervalBeginning && randomNumber <= (intervalBeginning + blacksmithCollapsedEventProbability)) BlacksmithCollapsedEvent();
            //Zwiększenie dolnego zakresu przedziału liczbowego, do kolejengo eventu
            intervalBeginning += blacksmithCollapsedEventProbability;

            //Sprawdzenie czy liczba mieści w przedziale eventu i wywołanie go jeśli mieści się
            if (randomNumber > intervalBeginning && randomNumber <= (intervalBeginning + attackEventProbability)) AttackEvent();
            //Zwiększenie dolnego zakresu przedziału liczbowego, do kolejengo eventu
            intervalBeginning += attackEventProbability;

            //Sprawdzenie czy liczba mieści w przedziale eventu i wywołanie go jeśli mieści się
            if (randomNumber > intervalBeginning && randomNumber <= (intervalBeginning +thiefEventProbability)) thiefEvent();
            //Zwiększenie dolnego zakresu przedziału liczbowego, do kolejengo eventu
            intervalBeginning += thiefEventProbability;

            //Sprawdzenie czy liczba mieści w przedziale eventu i wywołanie go jeśli mieści się
            if (randomNumber > intervalBeginning && randomNumber <= (intervalBeginning + desertionEventProbability)) desertionEvent();
        }
        /// <summary>
        /// Metoda przypisująca odpowiednie prawdopodobieństwo eventowi o zawaleniu się łuczarza
        /// </summary>
        private void FletcherCollapsedEventProbabilityChecker()
        {
            //Sprawdzenie poziomu rozbudowania łuczarza
            switch (player.FletcherLevel)
            {
                //Przypisanie prawdopodobieństwa zawalenia się w zależności od poziomu rozbudowania
                case 0: fletcherCollapsedEventProbability = 0; break;
                case 1: fletcherCollapsedEventProbability = 30; break;
                case 2: fletcherCollapsedEventProbability = 10; break;
                case 3: fletcherCollapsedEventProbability = 0; break;
            }
        }

        /// <summary>
        /// Metoda przypisująca odpowiednie prawdopodobieństwo eventowi o zawaleniu się tokarza
        /// </summary>
        private void PoleturnerCollapsedEventProbabilityChecker()
        {
            //Sprawdzenie poziomu rozbudowania tokarza
            switch (player.PoleturnerLevel)
            {
                //Przypisanie prawdopodobieństwa zawalenia się w zależności od poziomu rozbudowania
                case 0: poleturnerCollapsedEventProbability = 0; break;
                case 1: poleturnerCollapsedEventProbability = 30; break;
                case 2: poleturnerCollapsedEventProbability = 10; break;
                case 3: poleturnerCollapsedEventProbability = 0; break;
            }
        }

        /// <summary>
        /// Metoda przypisująca odpowiednie prawdopodobieństwo eventowi o zawaleniu się kowala
        /// </summary>
        private void BlacksmithCollapsedEventProbabilityChecker()
        {
            //Sprawdzenie poziomu rozbudowania kowala
            switch (player.BlacksmithLevel)
            {
                //Przypisanie prawdopodobieństwa zawalenia się w zależności od poziomu rozbudowania
                case 0: blacksmithCollapsedEventProbability = 0; break;
                case 1: blacksmithCollapsedEventProbability = 30; break;
                case 2: blacksmithCollapsedEventProbability = 10; break;
                case 3: blacksmithCollapsedEventProbability = 0; break;
            }
        }

        /// <summary>
        /// Metoda przypisująca odpowiednie prawdopodobieństwo eventowi o ataku na gracza
        /// </summary>
        private void AttackEventProbabilityChecker()
        {
            //Sprawdzenie poziomu rozbudowania muru
            switch (player.WallLevel)
            {
                //Przypisanie prawdopodobieństwa ataku w zależności od poziomu murów
                case 0: attackEventProbability = 100; break;
                case 1: attackEventProbability = 80; break;
                case 2: attackEventProbability = 60; break;
                case 3: attackEventProbability = 40; break;
                case 4: attackEventProbability = 20; break;
                case 5: attackEventProbability = 0; break;
            }
        }

        /// <summary>
        /// Metoda przypisująca odpowiednie prawdopodobieństwo eventowi o kradzieży ze składu
        /// </summary>
        private void ThiefEventProbabilityChecker()
        {
            //Sprawdzenie poziomu rozbudowania więzienia
            switch (player.PrisonLevel)
            {
                //Przypisanie prawdopodobieństwa ataku w zależności od poziomu więzienia
                case 0: thiefEventProbability = 100; break;
                case 1: thiefEventProbability = 80; break;
                case 2: thiefEventProbability = 60; break;
                case 3: thiefEventProbability = 40; break;
                case 4: thiefEventProbability = 20; break;
                case 5: thiefEventProbability = 0; break;
            }
        }

        /// <summary>
        /// Metoda przypisująca odpowiednie prawdopodobieństwo eventowi o dezercji żołnierzy
        /// </summary>
        private void DesertionEventProbabilityChecker()
        {
            //Obliczenie liczebności armi
            int armySize = player.Archers + player.Pikemen + player.Swordsmen;
            //Sprawdzenie czy gracz posiada armię i czy ma więcej niż 0 złota
            if(armySize > 0 && player.GoldAmount > 0)
            {
                //Przypisanie prawdopodobieństaw do eventu
                desertionEventProbability = 0;
            }
            else
            {
                //Przypisanie prawdopodobieństaw do eventu
                desertionEventProbability = 1000;
            }
            
        }

        /// <summary>
        /// Metoda sprawdzająca i zmieniająca prawdopodobieństwo wszystkich eventów w zależności od stanu gry
        /// </summary>
        private void EventsProbabilityChecker()
        {
            //Wywołanie metod przypisujących prawdopodobieństwo dla każdego eventu
            FletcherCollapsedEventProbabilityChecker();
            PoleturnerCollapsedEventProbabilityChecker();
            BlacksmithCollapsedEventProbabilityChecker();
            AttackEventProbabilityChecker();
            ThiefEventProbabilityChecker();
            DesertionEventProbabilityChecker();


        }

        /// <summary>
        /// Metoda odpowiedzialna za event zawalenia się łuczarza
        /// </summary>
        private void FletcherCollapseEvent()
        {
            //Zmniejszenie poziomu rozbudowania łuczarza
            player.FletcherLevel--;
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
            //Wyświetlenie odpowiedniego komunikatu
            MessageBox.Show("Zawalił się warsztat łuczarza, poziom ulepszenia spada","Zawalił się warsztat łuczarza");

        }

        /// <summary>
        /// Metoda odpowiedzialna za event zawalenia się tokarza
        /// </summary>
        private void PoleturnerCollapsedEvent()
        {
            //Zmniejszenie poziomu rozbudowania tokarza
            player.PoleturnerLevel--;
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
            //Wyświetlenie odpowiedniego komunikatu
            MessageBox.Show("Zawalił się warsztat tokarza, poziom ulepszenia spada", "Zawalił się warsztat tokarza");
        }

        /// <summary>
        /// Metoda odpowiedzialna za event zawalenia się kowala
        /// </summary>
        private void BlacksmithCollapsedEvent()
        {
            //Zmniejszenie poziomu rozbudowania kowala
            player.BlacksmithLevel--;
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
            //Wyświetlenie odpowiedniego komunikatu
            MessageBox.Show("Zawaliła się kuźnia kowala, poziom ulepszenia spada", "Zawaliła się kuźnia kowala");
        }

        /// <summary>
        /// Metoda odpowiedzialna za event ataku na gracza
        /// </summary>
        private void AttackEvent()
        {
            //Utworzenie obiektu Random
            Random random = new Random();
            //Wylosowanie liczby wrogich łuczników
            int enemyArchers = random.Next(1, 151);
            //Wylosowanie liczby wrogich pikinierów
            int enemyPikemen = random.Next(1, 151);
            //Wylosowanie liczby wrogich mieczników
            int enemySwordsman = random.Next(1, 51);
            //Obliczenie sumarycznej siły wojsk wroga
            int enemyStrength = enemyArchers + enemyPikemen*2 + enemySwordsman * 4;
            //Obliczenie sumarycznej siły wojsk gracza
            int playerStrength = player.Archers + player.Pikemen * 2 + player.Swordsmen * 4;
            //Sprawdzenie kto posiada silniejszą armię
            if(playerStrength > enemyStrength)
            {
                //Utworzenie zmienniej przechowującej komunikat
                String message = "Odparłeś atak wroga. Straciłeś: ";

                //Sprawdzenie czy gracz ma więcej łuczników od przeciwnika
                if (player.Archers > enemyArchers)
                {
                    //Dodanie informacji o stratach do komunikatu
                    message = message + (player.Archers - enemyArchers) + " łuczników";
                    //Odjęcie straconych łuczników od konta gracza
                    player.Archers -= enemyArchers;
                }
                else
                {
                    //Dodanie informacji o stratach do komunikatu
                    message = message + player.Archers + " łuczników";
                    //Wyzerowanie liczby łuczników na koncie gracza
                    player.Archers = 0;
                }

                //Sprawdzenie czy gracz ma więcej pikinierów od przeciwnika
                if (player.Pikemen > enemyPikemen)
                {
                    //Dodanie informacji o stratach do komunikatu
                    message = message + ", " + (player.Pikemen - enemyPikemen) + " pikinierów";
                    //Odjęcie straconych pikinierów od konta gracza
                    player.Pikemen -= enemyPikemen;
                }
                else
                {
                    //Dodanie informacji o stratach do komunikatu
                    message = message + ", " + player.Pikemen + " pikinierów";
                    //Wyzerowanie liczby pikinierów na koncie gracza
                    player.Pikemen = 0;
                }

                //Sprawdzenie czy gracz ma więcej mieczników od przeciwnika
                if (player.Swordsmen > enemySwordsman)
                {
                    //Dodanie informacji o stratach do komunikatu
                    message = message + ", " + (player.Swordsmen - enemySwordsman) + " mieczników.";
                    //Odjęcie straconych mieczników od konta gracza
                    player.Swordsmen -= enemySwordsman;
                }
                else
                {
                    //Dodanie informacji o stratach do komunikatu
                    message = message + ", " + player.Swordsmen + " mieczników.";
                    //Wyzerowanie liczby mieczników na koncie gracza
                    player.Swordsmen = 0;
                }
                //Zaktualizowanie danych w głównym oknie
                mainWindow.ValuesUpdate();
                //Wyświetlenie komunikatu
                MessageBox.Show(message, "Zaatakował cię wróg");
                               
            }
            else
            {
                //Wyzerowanie liczby wojsk na koncie gracza
                player.Archers = 0;
                player.Pikemen = 0;
                player.Swordsmen = 0;
                //Wyzerowanie liczby złota na koncie gracza
                player.GoldAmount = 0;
                //Zaktualizowanie danych w głównym oknie
                mainWindow.ValuesUpdate();
                //Wyświetlenie komunikatu
                MessageBox.Show("Wróg cię pokonał, straciłeś całą swoją armię i złoto", "Zaatakował cię wróg");
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za event kradzieży
        /// </summary>
        private void thiefEvent()
        {
            //Utworzenie obiektu Random
            Random random = new Random();
            //Wylosowanie liczby
            int resource = random.Next(1, 7);
            //Wybór kradzione surowca w zależności od wylosowanej liczby
            switch (resource)
            {
                case 1:
                    {
                        //Wyzerowanie liczby drewna na koncie gracza
                        player.WoodAmount = 0;
                        //Wyświetlenie komunikatu
                        MessageBox.Show("Zostałeś okradziony przez złodziei, straciłeś całe drewno", "Kradzież zapasów");
                    } break;
                case 2:
                    {
                        //Wyzerowanie liczby kamienia na koncie gracza
                        player.StoneAmount = 0;
                        //Wyświetlenie komunikatu
                        MessageBox.Show("Zostałeś okradziony przez złodziei, straciłeś cały kamień", "Kradzież zapasów");
                    } break;
                case 3:
                    {
                        //Wyzerowanie liczby żelaza na koncie gracza
                        player.IronAmount = 0;
                        //Wyświetlenie komunikatu
                        MessageBox.Show("Zostałeś okradziony przez złodziei, straciłeś całe żelazo", "Kradzież zapasów");
                    } break;
                case 4:
                    {
                        //Wyzerowanie liczby łuków na koncie gracza
                        player.BowsAmount = 0;
                        //Wyświetlenie komunikatu
                        MessageBox.Show("Zostałeś okradziony przez złodziei, straciłeś wszystkie łuki", "Kradzież zapasów");
                    } break;
                case 5:
                    {
                        //Wyzerowanie liczby pik na koncie gracza
                        player.PikesAmount = 0;
                        //Wyświetlenie komunikatu
                        MessageBox.Show("Zostałeś okradziony przez złodziei, straciłeś wszystkie piki", "Kradzież zapasów");
                    } break;
                case 6:
                    {
                        //Wyzerowanie liczby mieczy na koncie gracza
                        player.SwordsAmount = 0;
                        //Wyświetlenie komunikatu
                        MessageBox.Show("Zostałeś okradziony przez złodziei, straciłeś wszystkie miecze", "Kradzież zapasów");
                    } break;
            }
            //Aktualizacja danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Metoda odpowiedzialna za event dezercji
        /// </summary>
        private void desertionEvent()
        {
            //Sprawdzenie czy gracz posiada wojsko
            if ((player.Archers + player.Pikemen + player.Swordsmen) > 0) 
            {
                //Utworzenie zmienniej przechowującej komunikat
                String message = "Z powodu braku złota, zdezerterowało:";
                //Utworzenie obiektu Random
                Random random = new Random();
                if (player.Archers > 0)
                {
                    //Wylosowanie liczby dezertujących łuczników
                    int desertedArchers = random.Next(1, 21);
                    //Odjęcie liczby zdezerterowanych łuczników
                    player.Archers -= desertedArchers;
                    //Dodanie informacji o dezercji łuczników do komunikatu
                    message = message + "\nŁucznicy: " + desertedArchers;
                }
                if (player.Pikemen > 0)
                {
                    //Wylosowanie liczby dezertujących pikinierów
                    int desertedPikemen = random.Next(1, 21);
                    //Odjęcie liczby zdezerterowanych pikinierów
                    player.Pikemen -= desertedPikemen;
                    //Dodanie informacji o dezercji pikinierów do komunikatu
                    message = message + "\nPikinierzy: " + desertedPikemen;
                }
                if (player.Swordsmen > 0)
                {
                    //Wylosowanie liczby dezertujących mieczników
                    int desertedSwordsmen = random.Next(1, 11);
                    //Odjęcie liczby zdezerterowanych mieczników
                    player.Swordsmen -= desertedSwordsmen;
                    //Dodanie informacji o dezercji mieczników do komunikatu
                    message = message + "\nMiecznicy: " + desertedSwordsmen;
                } 
                //Aktualizacja danych wyświetlanych w głównym oknie
                mainWindow.ValuesUpdate();
                //Wyświetlenie komunikatu
                MessageBox.Show(message,"Dezercja"); 
            }
        }
    }
}
