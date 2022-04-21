using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.IO;

namespace _6800Emulator
{
    static class Program
    {
        public static string currentlyOpenFileName = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
