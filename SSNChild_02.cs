using System;
using System.Windows.Forms;

namespace ClientSharp
{
    public partial class SSNChild_02 : ClientSharp.SetServerName
    {
        public SSNChild_02()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please, don't left this filed empty");
            }

            NetScan scan = this.Owner as NetScan;
            if (!scan.DoesExist(textBox1.Text, StrType.EserverName))
            {
                scan.AddRow(textBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("This name is already defined!");
            }
        }
    }
}
