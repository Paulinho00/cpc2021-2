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
    public partial class FormRecruitmentWindow : Form
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
        /// Zmienna przechowująca referencję do obiektu głównego okna
        /// </summary>
        private FormMainWindow formMainWindow;



        public FormRecruitmentWindow(Player player, Timer timer, FormMainWindow formMainWindow)
        {
            InitializeComponent();
            //Przypisanie referencji obiektu Player
            this.player = player;
            //Przypisanie referencji obiektu Timer
            timerFromMainWindow = timer;
            //Przypisanie referencji obiektu FormMainWindow
            this.formMainWindow = formMainWindow;
            //Zatrzymanie Timera
            timerFromMainWindow.Stop();
            //Wywołanie metody aktualizujacej dane w oknie
            ValuesUpdate();
        }

        /// <summary>
        /// Aktualizacja wyświetlanych danych i maksymalnego zakresu suwaków
        /// </summary>
        private void ValuesUpdate()
        {
            //Wyświetlenie aktualnej liczby złota
            labelGoldAmount.Text = player.GoldAmount.ToString();
            //Wyświetlenie aktualnej liczby łuków
            labelBowsAmount.Text = player.BowsAmount.ToString();
            //Wyświetlenie aktualnej liczby pik
            labelPikesAmount.Text = player.PikesAmount.ToString();
            //Wyświetlenie aktualnej liczby mieczy
            labelSwordsAmount.Text = player.SwordsAmount.ToString();
            //Ustawienie maksymalnej liczby łuczników, możliwej do zrekrutowania, na suwaku
            trackBarArchers.Maximum = Math.Min((int)player.GoldAmount / 30, player.BowsAmount);
            //Ustawienie maksymalnej liczby pikinierów, możliwej do zrekrutowania, na suwaku
            trackBarPikemen.Maximum = Math.Min((int)player.GoldAmount / 50, player.PikesAmount);
            //Ustawienie maksymalnej liczby mieczników, możliwej do zrekrutowania, na suwaku
            trackBarSwordsmen.Maximum = Math.Min((int)player.GoldAmount / 100, player.SwordsAmount);
        }


        /// <summary>
        /// Wyświetlenie wartości wskazywanej przez suwak dla łuczników
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBarArchers_Scroll(object sender, EventArgs e)
        {
            // Wyświetlenie wartości wskazywanej przez suwak
            labelArchersTrackBarValue.Text = trackBarArchers.Value.ToString();
        }

        /// <summary>
        /// Wyświetlenie wartości wskazywanej przez suwak dla pikinierów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBarPikemen_Scroll(object sender, EventArgs e)
        {
            // Wyświetlenie wartości wskazywanej przez suwak
            labelPikemenTrackBarValue.Text = trackBarPikemen.Value.ToString();
        }

        /// <summary>
        /// Wyświetlenie wartości wskazywanej przez suwak dla mieczników
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBarSwordsmen_Scroll(object sender, EventArgs e)
        {
            // Wyświetlenie wartości wskazywanej przez suwak
            labelSwordmenTrackBarValue.Text = trackBarSwordsmen.Value.ToString();
        }

        /// <summary>
        /// Rekrutacja wybranej liczby wojsk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRecruit_Click(object sender, EventArgs e)
        {
            //Zapisanie na koncie gracza zrekrutowanej liczby wojsk i odjęcie odpowiednich kosztów
            player.Recruitment(trackBarArchers.Value, trackBarPikemen.Value, trackBarSwordsmen.Value);
            //Zaktualizowanie wartości na suwakach
            ValuesUpdate();
            //Zaktualizowanie danych wyświetlanych w głównym oknie
            formMainWindow.ValuesUpdate();
        }

        /// <summary>
        /// Metoda wywoływana w momencie próby zamknięcia okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRecruitmentWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Ponowne wystartowanie timera z okna głównego
            timerFromMainWindow.Start();
        }
    }
}
