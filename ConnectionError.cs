using System;
using System.Windows.Forms;

namespace ClientSharp
{
    public partial class ConnectionError : Form
    {
        public ConnectionError()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu menu = this.Owner as MainMenu;
            menu.Show();
            menu.Connect();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectionError_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
