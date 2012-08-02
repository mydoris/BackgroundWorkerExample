using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BackgroundWorkerExample;

namespace TimeConsumingOperation
{



    public class Program
    {
        private Program()
        {
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
