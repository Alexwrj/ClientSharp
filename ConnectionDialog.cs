using System;
using System.Windows.Forms;
using System.Net;

namespace ClientSharp
{
    public partial class ConnectionDialog : Form
    {
        private IPAddress ip;

        public ConnectionDialog()
        {
            InitializeComponent();
        }

        public void init()
        {
            MainMenu menu = this.Owner as MainMenu;
            try
            {
                ip = menu.GetIP();
                label1.Text = "Connect to " + ip.ToString() + "?";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu menu = this.Owner as MainMenu;
            menu.Show();
            menu.Connect();
            this.Hide();
        }

        private void ConnectionDialog_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDialog form = new AddDialog();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void ConnectionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
