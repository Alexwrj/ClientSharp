using System;
using System.Windows.Forms;
using System.IO;

namespace ClientSharp
{
    public partial class Form2 : Form
    {
        private string IP;
        private string PORT;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != " " && textBox2.Text != "" && textBox2.Text != " ")
            {
                try
                {
                    DirectoryInfo data = new DirectoryInfo("Client_info");
                    data.Create();

                    var sw = new StreamWriter(@"Client_info/data_info.txt");
                    sw.WriteLine(textBox1.Text + ':' + textBox2.Text);
                    sw.Close();

                    this.Hide();

                    Application.Restart();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                
            }
        }
    }
}
