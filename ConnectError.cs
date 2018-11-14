using System;
using System.Windows.Forms;

namespace ClientSharp
{
    public partial class ConnectError : Form
    {
        public ConnectError()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
