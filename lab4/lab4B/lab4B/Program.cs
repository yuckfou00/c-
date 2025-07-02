using System;
using System.Windows.Forms;
/*
 * Your Name: Omar Zahraoui
 * Student Number: 000905815
 * Statement of Authorship: I, Omar Zahraoui, certify that this material is my original work. No other person's work has been used without due acknowledgement.
 */
namespace Lab4b
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
