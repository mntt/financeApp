using System;
using System.Windows.Forms;

namespace financeApp
{
    public partial class LoadingScreen : Form
    {
        private int interval { get; set; }
        public LoadingScreen(int _interval)
        {
            InitializeComponent();
            interval = _interval;
            this.Text = String.Empty;
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            timer.Stop();
            Close();
        }

        static public void ShowLoadingScreen(int _interval)
        {                      
            Application.Run(new LoadingScreen(_interval));        
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timer.Interval = interval;
            timer.Start();
        }

    }
}
