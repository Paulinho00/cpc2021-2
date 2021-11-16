﻿using System;
using System.Windows.Forms;
using CPC2021_2_Lab2.Forms;

namespace CPC2021_2_Lab2
{
    static class Program
    {
        public static bool Logged;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Application.Run(new FormLogin());

            //jeśli udało się zalogować uruchom główne okno, inaczej zakończ działanie programu
            // if(Logged)
                Application.Run(new FormMain());
        }
    }
}
