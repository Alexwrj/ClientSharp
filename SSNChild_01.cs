using System;
using System.Windows.Forms;

namespace ClientSharp
{
    public partial class SSNChild_01 : ClientSharp.SetServerName
    {
        public SSNChild_01(string sName)
        {
            InitializeComponent();
            textBox1.Text = sName;
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
                scan.ChangeRow(textBox1.Text, StrType.EserverName);
                this.Close();
            }
            else
            {
                MessageBox.Show("This name is already defined!");
            }
        }
    }
}
