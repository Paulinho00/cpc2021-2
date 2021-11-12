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
        /// <summary>
        /// Zmienna przechowująca informację o wyborze opcji handlu przez gracza
        /// </summary>
        private Boolean isBuying;
        /// <summary>
        /// Zmienna przechowująca referencję do obiektu głównego okna
        /// </summary>
        private FormMainWindow mainWindow;

        public FormTradeWindow(Player player, Timer timer, FormMainWindow formMainWindow)
        {
            InitializeComponent();
            //Przypisanie referencji do obiektu gracza
            this.player = player;
            //Przypisanie referencji do obiektu Timera
            timerFromMainWindow = timer;
            //Zatrzymanie timera z głównego okna
            timerFromMainWindow.Stop();
            //Przypisanie referencji do obiektu FormMainWindow
            mainWindow = formMainWindow;
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
        }
       
        /// <summary>
        /// Metoda aktualizuje wartości liczbowe w oknie
        /// </summary>
        private void ValuesUpdate()
        {
            //Wyświetlenie aktualnie posiadanej liczby złota
            labelGoldAmount.Text = player.GoldAmount.ToString();
            //Wyświetlenie aktualnie posiadanej liczby drewna
            labelWoodAmount.Text = player.WoodAmount.ToString();
            //Wyświetlenie aktualnie posiadanej liczby kamienia
            labelStoneAmount.Text = player.StoneAmount.ToString();
            //Wyświetlenie aktualnie posiadanej liczby żelaza 
            labelIronAmount.Text = player.IronAmount.ToString();
            //Wyświetlenie aktualnie posiadanej liczby łuków
            labelBowsAmount.Text = player.BowsAmount.ToString();
            //Wyświetlenie aktualnie posiadanej liczby pik
            labelPikesAmount.Text = player.PikesAmount.ToString();
            //Wyświetlenie aktualnie posiadanej liczby mieczy
            labelSwordsAmount.Text = player.SwordsAmount.ToString();
        }

        /// <summary>
        /// Metoda aktywująca lub dezaktywująca przycisk, w zależności od posiadanych zasobów
        /// </summary>
        /// <param name="button">referencja do obiektu przycisku, którego widoczność ma być zmieniona</param>
        /// <param name="price">cena surowca za który odpowiada przycisk</param>
        /// <param name="resourceAmount">ilość danego surowca, posiadana przez gracza</param>
        /// <param name="resourceForTrade">ilość surowca wymaganego do handlu wykonywanego przez przycisk</param>
        private void ButtonEnabledChanger(Button button, int price, int resourceAmount, int resourceForTrade)
        {
            //Sprawdzenie czy gracz wybrał opcję kupna
            if (isBuying)
            {
                //Sprawdzenie czy gracz ma odpowiednią ilość złota
                if(player.GoldAmount >= price)
                {
                    //Włączenie przycisku
                    button.Enabled = true;
                }
                else
                {
                    //Wyłączenie przycisku
                    button.Enabled = false;
                }
            }
            else
            {
                //Sprawdzenie czy gracz ma odpowiednią ilość surowca na handel
                if(resourceAmount >= resourceForTrade)
                {
                    //Włączenie przycisku
                    button.Enabled = true;
                }
                else
                {
                    //Wyłączenie przycisku
                    button.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Metoda odpowiednio zmieniająca widoczność wszystkich przycisków handlu
        /// </summary>
        private void UpdateButtonsEnabled()
        {
            //Wywołanie metody aktywującej/deazaktywującej przyciski do handlu drewnem
            ButtonEnabledChanger(buttonTradeWood1, 1, player.WoodAmount, 1);
            ButtonEnabledChanger(buttonTradeWood10, 10, player.WoodAmount, 10);
            ButtonEnabledChanger(buttonTradeWood100, 100, player.WoodAmount, 100);
            //Wywołanie metody aktywującej/deazaktywującej przyciski do handlu kamieniem
            ButtonEnabledChanger(buttonTradeStone1, 4, player.StoneAmount, 1);
            ButtonEnabledChanger(buttonTradeStone10, 40, player.StoneAmount, 10);
            ButtonEnabledChanger(buttonTradeStone100, 400, player.StoneAmount, 100);
            //Wywołanie metody aktywującej/deazaktywującej przyciski do handlu żelazem
            ButtonEnabledChanger(buttonTradeIron1, 8, player.IronAmount, 1);
            ButtonEnabledChanger(buttonTradeIron10, 80, player.IronAmount, 10);
            ButtonEnabledChanger(buttonTradeIron100, 800, player.IronAmount, 100);
            //Wywołanie metody aktywującej/deazaktywującej przyciski do handlu łukami
            ButtonEnabledChanger(buttonTradeBows1, 10, player.BowsAmount, 1);
            ButtonEnabledChanger(buttonTradeBows10, 100, player.BowsAmount, 10);
            ButtonEnabledChanger(buttonTradeBows100, 1000, player.BowsAmount, 100);
            //Wywołanie metody aktywującej/deazaktywującej przyciski do handlu pikami
            ButtonEnabledChanger(buttonTradePikes1, 12, player.PikesAmount, 1);
            ButtonEnabledChanger(buttonTradePikes10, 120, player.PikesAmount, 10);
            ButtonEnabledChanger(buttonTradePikes100, 1200, player.PikesAmount, 100);
            //Wywołanie metody aktywującej/deazaktywującej przyciski do handlu pikami
            ButtonEnabledChanger(buttonTradeSwords1, 15, player.SwordsAmount, 1);
            ButtonEnabledChanger(buttonTradeSwords10, 150, player.SwordsAmount, 10);
            ButtonEnabledChanger(buttonTradeSwords100, 1500, player.SwordsAmount, 100);

        }
        /// <summary>
        /// Wybranie opcji sprzedawania w oknie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonSell_CheckedChanged(object sender, EventArgs e)
        {
            //Zapisanie informacji o wyborze gracza w zmiennej
            isBuying = false;
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
        }

        /// <summary>
        /// Wybranie opcji kupowania w oknie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonBuy_CheckedChanged(object sender, EventArgs e)
        {
            //Zapisanie informacji o wyborze gracza w zmiennej
            isBuying = true;
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
        }

        /// <summary>
        /// Przycisk do handlu 1 drewnem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeWood1_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeWood(1, 1, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
            
        }

        /// <summary>
        /// Przycisk do handlu 10 drewnami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeWood10_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeWood(10, 10, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 100 drewnami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeWood100_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeWood(100, 100, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 1 kamieniem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeStone1_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeStone(1, 4, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 10 kamieniami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeStone10_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeStone(10, 40, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();

        }

        /// <summary>
        /// Przycisk do handlu 100 kamieniami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeStone100_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeStone(100, 400, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 1 żelazem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeIron1_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeIron(1, 8, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();

        }

        /// <summary>
        /// Przycisk do handlu 10 żelazami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeIron10_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeIron(10, 80, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 100 żelazami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeIron100_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeIron(100, 800, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 1 łukiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeBows1_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeBows(1, 10, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 10 łukami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeBows10_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeBows(10, 100, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 100 łukami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeBows100_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeBows(100, 1000, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 1 piką
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradePikes1_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradePikes(1, 12, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 10 pikami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradePikes10_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradePikes(10, 120, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 100 pikami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradePikes100_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradePikes(100, 1200, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 1 mieczem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeSwords1_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeSwords(1, 15, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 10 mieczami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeSwords10_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeSwords(10, 150, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Przycisk do handlu 100 mieczami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTradeSwords100_Click(object sender, EventArgs e)
        {
            //Wywołanie metody wymieniającej złoto i surowce na koncie gracza
            player.TradeSwords(100, 1500, isBuying);
            //Zaktualizowanie danych w oknie
            ValuesUpdate();
            //Aktywacja/dezaktywacja odpowiednich przycisków
            UpdateButtonsEnabled();
            //Zaktualizowanie danych w głównym oknie
            mainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Metoda wywoływana podczas próby zamknięcia okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTradeWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Ponowne wystartowanie timera z okna głównego
            timerFromMainWindow.Start();
        }
    }
}
