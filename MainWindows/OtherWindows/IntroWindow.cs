using System;
using System.Drawing;
using System.Windows.Forms;


namespace financeApp
{
    public partial class IntroWindow : Form
    {
        public IntroWindow()
        {
            InitializeComponent();
            SetStylesAndLooks();
            introNextButton.Select();
        }

        private void introNextButton_Click(object sender, EventArgs e)
        {
            IntroWindow2 intro2 = new IntroWindow2(true);
            this.Hide();
            intro2.Show();
            intro2.Focus();
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetButtonStyle(introNextButton);
            Connection.style.SetLabelStyle(greetings, 9);
            Connection.style.SetLabelStyle(text1, 8);
            Connection.style.SetLabelStyle(text2, 8);
            Connection.style.SetLabelStyle(text3, 8);
        }

        private void introNextButton_MouseEnter(object sender, EventArgs e)
        {
            introNextButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void introNextButton_MouseLeave(object sender, EventArgs e)
        {
            introNextButton.ForeColor = Color.White;
        }
    }
}
