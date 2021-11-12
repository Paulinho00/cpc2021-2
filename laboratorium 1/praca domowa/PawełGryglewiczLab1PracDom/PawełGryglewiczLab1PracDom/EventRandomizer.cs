using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Zmienna przechowująca prawdopodobieństwo wystąpienia eventu o pojawianiu się zbójów
        /// </summary>
        private int desertionProbability;
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu gracza ze stanem konta
        /// </summary>
        private Player player;

        public EventRandomizer(Player player)
        {
            //Przypisanie referencji do obiektu gracza
            this.player = player;
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
                desertionProbability = 0;
            }
            else
            {
                //Przypisanie prawdopodobieństaw do eventu
                desertionProbability = 1000;
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

    }
}
