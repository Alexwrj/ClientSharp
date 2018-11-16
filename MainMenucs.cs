using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientSharp
{
    public partial class MainMenu : Form
    {
        private IPAddress ip = null;
        private int port = 0;
        static private Socket client;
        private string incommingMessage;
        private Thread thread;
        private NetScan nscan;

        public MainMenu()
        {
            InitializeComponent();
            //  if (!this.CheckInternetConnection())
            //  {
            //      Environment.Exit(1);
            //  }

            nscan = new NetScan();
            nscan.Owner = this;
            nscan.Show();
        }

        public bool CheckInternetConnection()
        {
            try
            {
                using (var webClient = new WebClient())
                using (var stream = webClient.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch 
            {
                MessageBox.Show("No internet connection!");
                return false;
            }
        }

        public bool SetSettings(string ip, string port)
        {
            try
            {
                this.ip = IPAddress.Parse(ip);
                this.port = Convert.ToInt32(port);
                Settings.ForeColor = Color.Green;
                Settings.Text = "Current settings:\nServer IP: " +
                    ip + "\nServer Port: " + port;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid settings!");
                return false;
            }
        }

        public void SendMessage(int signal)
        {
            byte[] buff = new byte[1024];
            buff = Encoding.UTF8.GetBytes(signal.ToString());
            client.Send(buff);
        }

        public string getMessage()
        {
            return incommingMessage;
        }

        public void ReceiveMessage()
        {
            byte [] bytesGot = new byte[1024];
            int buff = 0;

            while (true)
            {
                try
                {
                    buff = client.Receive(bytesGot, bytesGot.Length, 0);
                    incommingMessage = Encoding.UTF8.GetString(bytesGot, 0, buff);
                }
                catch
                {
                    //server stopped
                    MessageBox.Show("Server was stopped. Please, close or restart the application");
                    Application.Exit();
                    break;
                }

                Int32 inm;

                if (Int32.TryParse(incommingMessage, out inm))
                {
                    switch (inm)
                    {
                        case 0:
                            //server stopped
                            MessageBox.Show("Server was stopped. Please, close or restart the application");
                            //Application.Exit();
                            break;
                        case 1:
                            //server was relaunched
                            MessageBox.Show("Server was restarted. Please, close or restart the application");
                            //Application.Exit();
                            break;
                    }
                }
            }
        }

        public bool Connect()
        {
            if (ip == null)
            {
                return false;
            }
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ip, port);
                thread = new Thread(delegate ()
                {
                    ReceiveMessage();
                });
                thread.Name = "connectionThread";
                thread.Start();
                nscan.Hide();
                return true;
            }
            catch
            {
                //MessageBox.Show("Connection error: " + ex.Message);
                MessageBox.Show("Error while connecting. \n\rPlease, make sure server is run in application \n\rand the port is correct.");
                return false;
            }
        }

        public IPAddress GetIP()
        {
            return ip;
        }

        public Socket GetClient()
        {
            return client;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Owner = this;
            form.init();
            form.Show();
            //open configurate panel
            this.SendMessage(31);
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Demo
            this.SendMessage(32);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 form = new Form2();
            //form.Show();
            //NetScan scan = new NetScan(true);
            this.Disconnect();
            nscan.EnableButtons();
            nscan.KillScanThread();
            nscan.Show();
            this.Hide();
        }

        public void UnhideMM()
        {
            this.Visible = true;
            //this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Walk
            this.SendMessage(33);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Settings
            this.SendMessage(34);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Contacts
            this.SendMessage(35);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Quit
            nscan.OnExit();
            this.SendMessage(36);
            this.KillConnectionThread();
            Application.Exit();
        }

        private void Disconnect()
        {
            //Quiet exit
            this.SendMessage(37);
            this.KillConnectionThread();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            nscan.OnExit();
            this.Disconnect();
            Application.Exit();
        }

        private void KillConnectionThread()
        {
            if (thread != null && thread.IsAlive)
            {
                //need to kill listen thread also
                //that stuff doesn't work as I expected
                client.Disconnect(false);
                thread.Abort();
                thread.Join();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
