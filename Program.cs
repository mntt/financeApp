using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financeApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();            
            Application.SetCompatibleTextRenderingDefault(false);
            LoadingScreen.ShowLoadingScreen(5000);
            Application.Run(new Login());
        }
        
    }
}
