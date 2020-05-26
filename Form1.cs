using RPG.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class Form1 : Form
    {
        private GameServer gameServer;
        private GameClient gameClient;

        private Handler handler;

        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            Label.CheckForIllegalCrossThreadCalls = false;

            HostIP_textBox.Text = GetLocalIP();
            form2 = new Form2();
            handler = new Handler(this, form2);
        }
        private void Join_button_Click(object sender, EventArgs e)
        {
            PlayerMP player = new PlayerMP(SettingsName_textBox.Text, JoinIP_textBox.Text, GetRandomUnusedPort());
            gameClient = new GameClient(handler, player.ipAddress, int.Parse(JoinPort_textBox.Text), player.port);

            Packet00Login loginPacket = new Packet00Login(player.username, player.port.ToString());
            loginPacket.WriteData(gameClient);

            form2.Show();
        }

        private void Host_button_Click(object sender, EventArgs e)
        {
            PlayerMP player = new PlayerMP(SettingsName_textBox.Text, HostIP_textBox.Text, GetRandomUnusedPort());
            gameServer = new GameServer(handler, player.ipAddress, int.Parse(HostPort_textBox.Text));
            gameClient = new GameClient(handler, player.ipAddress, int.Parse(HostPort_textBox.Text), player.port);

            Packet00Login loginPacket = new Packet00Login(player.username, player.port.ToString());
            loginPacket.WriteData(gameClient);

            form2.Show();
        }

        private String GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }
        private int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}