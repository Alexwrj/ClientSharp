using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClientSharp
{
    public enum StrType
    {
        EmacAddress,
        EserverName,
        EipAddress,
        Eport,
        EautoConn, 
        ElastIP
    }

    public partial class NetScan : Form
    {
        static private String IP;
        private string host;
        private List<string> addrs = new List<string>();
        private List<string> savedAddrs = new List<string>();
        private List<string> macs = new List<string>();
        private Thread thread;
        private const int timeout = 3000;
        private SqlConnection sqlConnect;
        private bool auto_connection;
        private Regex regIP = new Regex(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        private bool singleConnTry = false;

        public NetScan()
        {
            InitializeComponent();
            ConnectionButton.Enabled = false;
            scanButton.Enabled = false;

            this.ConnectDB();

            if (!singleConnTry)
            {
                this.StartScan();
            }
            
        }

        public void EnableButtons()
        {
            ConnectionButton.Enabled = true;
            scanButton.Enabled = true;
            StopScanButton.Enabled = false;
        }

        private void TryConnect()
        {
            Ping ping = new Ping();
            string ip = GetData(null, StrType.ElastIP);
            PingReply reply = ping.Send(ip);

            if (reply.Status == IPStatus.Success)
            {
                MainMenu menu = this.Owner as MainMenu;
                if (!menu.SetSettings(ip, GetData(null, StrType.Eport)))
                {
                     MessageBox.Show("Settings are incorrect");
                }

                menu.Connect();
                menu.Show();
            }
        }

        private void StartScan()
        {
            thread = new Thread(() => Scan())
            {
                Name = "Netscan"
            };
            thread.Start();
        }

        private async void Scan()
        {
            host = Dns.GetHostName();
#pragma warning disable CS0618 // Тип или член устарел
            IPAddress[] IPs = Dns.GetHostByName(host).AddressList;
#pragma warning restore CS0618 // Тип или член устарел
            string[] sub;
            var tasks = new List<Task>();
            foreach (var addr in IPs)
            {
                IP = addr.ToString();
                sub = IP.Split('.');
                IP = sub[0] + "." + sub[1] + "." + sub[2] + ".";
                
                for (var i = 1; i < 255; i++)
                {
                    string subnet = IP + i.ToString();
                    tasks.Add(PingAndUpdateAsync(new Ping(), subnet));
                    label2.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = "Current: " + subnet;
                    });
                    //Thread.Sleep(5);
                }
            }

            await Task.WhenAll(tasks).ContinueWith(t =>
            {
                ConnectionButton.Invoke((MethodInvoker)delegate
                {
                    ConnectionButton.Enabled = true;
                });

                scanButton.Invoke((MethodInvoker)delegate
                {
                    scanButton.Enabled = true;
                });

                StopScanButton.Invoke((MethodInvoker)delegate
                {
                    StopScanButton.Enabled = false;
                });

                savedAddrs = addrs;
                this.CheckNameMatches();

                listBox1.Invoke((MethodInvoker)delegate
                {
                    foreach (string ad in addrs)
                    {
                        listBox1.Items.Add(ad);
                    }
                });
            });
        }

        private async Task PingAndUpdateAsync(Ping ping, string ip)
        {
            var reply = await ping.SendPingAsync(ip, timeout);

            if (reply.Status == IPStatus.Success)
            {
                IPAddress address = IPAddress.Parse(ip);
                IPHostEntry hostEntry = Dns.GetHostEntry(address);
                addrs.Add(address.ToString());
                macs.Add(NativeMethods.GetMacAddress(address.ToString()));
            }
        }

        private async void ConnectDB()
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RCDB.mdf;Integrated Security=True;MultipleActiveResultSets=True";

            sqlConnect = new SqlConnection(connString);

            await sqlConnect.OpenAsync();

            PortTextBox.Text = GetData(null, StrType.Eport);
            auto_connection = Convert.ToBoolean(GetData(null, StrType.EautoConn));
            autoConnectCHB.Checked = auto_connection;

            if (auto_connection)
            {
                singleConnTry = true;
                this.TryConnect();
            }
        }

        private void StopScanButton_Click(object sender, EventArgs e)
        {
            this.KillScanThread();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.KillScanThread();
            Application.Exit();
        }

        public void KillScanThread()
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please, select server from list.");
                return;
            }

            if (String.IsNullOrEmpty(PortTextBox.Text))
            {
                MessageBox.Show("Please, don't leave port as empty string.");
                return;
            }

            MainMenu menu = this.Owner as MainMenu;

            if (regIP.IsMatch(addrs[listBox1.SelectedIndex]))
            {
                menu.SetSettings(addrs[listBox1.SelectedIndex], PortTextBox.Text);
            }
            else
            {
                menu.SetSettings(GetData(macs[listBox1.SelectedIndex], StrType.EipAddress), PortTextBox.Text);
            }

            if (regIP.IsMatch(addrs[listBox1.SelectedIndex]))
            {
                SSNChild_02 form = new SSNChild_02
                {
                    Owner = this
                };
                form.ShowDialog();
            }

            if (menu.Connect())
            {
                menu.Show();
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            ConnectionButton.Enabled = false;
            scanButton.Enabled = false;
            StopScanButton.Enabled = true;
            listBox1.Items.Clear();
            if (addrs != null)
            {
                addrs.Clear();
                macs.Clear();
            }
            StartScan();
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //int index = listBox1.FindString();
                ((ListBox)sender).SelectedIndex = ((ListBox)sender).IndexFromPoint(e.Location);

                var info = listBox1.SelectedIndex;
                
                if(info >= 0)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
                
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SSNChild_01 child_01 = new SSNChild_01(listBox1.SelectedItem.ToString())
            {
                Owner = this
            };
            child_01.ShowDialog();
        }

        public bool DoesExist(string macOrName, StrType type)
        {
            SqlCommand sqlCommand = null;
            switch (type)
            {
                case StrType.EserverName:
                    sqlCommand = new SqlCommand("SELECT (name) FROM [server_table] WHERE name=@macOrName;", sqlConnect);
                    break;
                case StrType.EmacAddress:
                    sqlCommand = new SqlCommand("SELECT (name) FROM [server_table] WHERE mac=@macOrName;", sqlConnect);
                    break;
                    
            }

            sqlCommand.Parameters.AddWithValue("macOrName", macOrName);
            String result = Convert.ToString(sqlCommand.ExecuteScalar());

            return !String.IsNullOrEmpty(result);
        }

        private string GetData(string mac, StrType type)
        {
            SqlCommand sqlCommand = null;
            switch (type)
            {
                case StrType.EserverName:
                    sqlCommand = new SqlCommand("SELECT (name) FROM [server_table] WHERE mac=@mac;", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("mac", mac);
                    break;
                case StrType.EipAddress:
                    sqlCommand = new SqlCommand("SELECT (ip) FROM [server_table] WHERE mac=@mac;", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("mac", mac);
                    break;
                case StrType.Eport:
                    sqlCommand = new SqlCommand("SELECT (port) FROM [settings] WHERE id=1;", sqlConnect);
                    break;
                case StrType.EautoConn:
                    sqlCommand = new SqlCommand("SELECT (auto_connection) FROM [settings] WHERE id=1;", sqlConnect);
                    break;
                case StrType.ElastIP:
                    sqlCommand = new SqlCommand("SELECT (prev_server) FROM [settings] WHERE id=1;", sqlConnect);
                    break;
            }
            
            return Convert.ToString(sqlCommand.ExecuteScalar());
        }

        public async void AddRow(string serverName)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [server_table](ip, mac, name) VALUES(@ip, @mac, @name)", sqlConnect);
            sqlCommand.Parameters.AddWithValue("ip", addrs[listBox1.SelectedIndex]);
            sqlCommand.Parameters.AddWithValue("mac", macs[listBox1.SelectedIndex]);
            sqlCommand.Parameters.AddWithValue("name", serverName);

            await sqlCommand.ExecuteNonQueryAsync();
        }

        //not tested yet! Need to make 5-th point first
        public async void ChangeRow(string strValue, StrType type)
        {
            SqlCommand sqlCommand = null;
            switch (type)
            {
                case StrType.Eport:
                    sqlCommand = new SqlCommand("UPDATE [settings] SET port=@port WHERE id=1", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("port", strValue);
                    break;
                case StrType.EautoConn:
                    sqlCommand = new SqlCommand("UPDATE [settings] SET auto_connection=@auto WHERE id=1", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("auto", strValue);
                    break;
                case StrType.ElastIP:
                    sqlCommand = new SqlCommand("UPDATE [settings] SET prev_server=@auto WHERE id=1", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("auto", strValue);
                    break;
                case StrType.EserverName:
                    sqlCommand = new SqlCommand("UPDATE [server_table] SET name=@newName WHERE name=@name", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("newName", strValue);
                    sqlCommand.Parameters.AddWithValue("name", listBox1.SelectedItem.ToString());
                    break;
                case StrType.EipAddress:
                    sqlCommand = new SqlCommand("UPDATE [server_table] SET ip=@new_ip WHERE ip=@old_ip", sqlConnect);
                    sqlCommand.Parameters.AddWithValue("new_ip", strValue);
                    sqlCommand.Parameters.AddWithValue("old_ip", listBox1.SelectedItem.ToString());
                    break;
            }

            await sqlCommand.ExecuteNonQueryAsync();
        }

        private async void UpdateIP(string newIP, string oldIP)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE [server_table] SET ip=@new_ip WHERE ip=@old_ip", sqlConnect);
            sqlCommand.Parameters.AddWithValue("new_ip", newIP);
            sqlCommand.Parameters.AddWithValue("old_ip", oldIP);

            await sqlCommand.ExecuteNonQueryAsync();
        }

        private void CheckNameMatches()
        {
            for (var i = 0; i < macs.Count; i++)
            {
                if (DoesExist(macs[i], StrType.EmacAddress))
                {
                    if (savedAddrs[i] != GetData(macs[i], StrType.EipAddress))
                    {
                        UpdateIP(savedAddrs[i], GetData(GetData(macs[i], StrType.EserverName), StrType.EipAddress));
                    }

                    addrs[i] = GetData(macs[i], StrType.EserverName);
                }
            }
        }

        private void NetScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.OnExit();
            Application.Exit();
        }

        public void OnExit()
        {
            ChangeRow(PortTextBox.Text, StrType.Eport);
            ChangeRow(Convert.ToString(autoConnectCHB.Checked), StrType.EautoConn);

            try
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    ChangeRow(GetData(macs[listBox1.SelectedIndex], StrType.EipAddress), StrType.ElastIP);
                }
            }
            catch
            {
                return; // just a trick that works, but occasionally
            }
        }

        private void PortTextBox_TextChanged(object sender, EventArgs e)
        {
            var str = PortTextBox.Text;
            Int32 res;

            if (!Int32.TryParse(str, out res))
            {
                PortTextBox.Text = "";
            }
        }
    }
}
