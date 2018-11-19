using System;
using System.Windows.Forms;

namespace ClientSharp
{
    public partial class Form1 : Form
    {
        private MainMenu menu;

        public Form1()
        {
            InitializeComponent();
        }

        public void init()
        {
            menu = this.Owner as MainMenu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(4);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(5);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(7);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(8);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(9);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(10);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(11);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(13);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(14);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(15);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(16);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(17);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(18);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(19);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(20);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            menu = this.Owner as MainMenu;
            menu.SendMessage(21);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //left arrow
            menu = this.Owner as MainMenu;
            menu.SendMessage(22);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //right arrow
            menu = this.Owner as MainMenu;
            menu.SendMessage(23);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //spray
            menu = this.Owner as MainMenu;
            menu.SendMessage(25);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //rotate
            menu = this.Owner as MainMenu;
            menu.SendMessage(26);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //eye
            menu = this.Owner as MainMenu;
            menu.SendMessage(27);
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            //info
            menu = this.Owner as MainMenu;
            menu.SendMessage(28);
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            //settings
            menu = this.Owner as MainMenu;
            menu.UnhideMM();
            this.Close();
            menu.SendMessage(29);
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            //exit
            menu = this.Owner as MainMenu;
            menu.Show();
            this.Hide();
            this.Close();
            menu.SendMessage(30);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit
            menu = this.Owner as MainMenu;
            menu.Show();
        }
    }

}