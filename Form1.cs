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
        private static GameClient gameClient;
        private static PlayerMP player;

        private static Form1 loginForm;
        private static Form2 gameForm;

        public Form1()
        {
            InitializeComponent();
            Label.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;

            loginForm = this;
            gameForm = new Form2();

        }

        private void Join_button_Click(object sender, EventArgs e)
        {
            player = new PlayerMP(SettingsName_textBox.Text, null, GetRandomUnusedPort());

            gameClient = new GameClient(gameForm, player, JoinIP_textBox.Text, int.Parse(JoinPort_textBox.Text));

            Packet00Login loginPacket = new Packet00Login(player.username, player.port.ToString());
            loginPacket.WriteData(gameClient);

            loginForm.Hide();
            gameForm.Show();
        }

        private void Host_button_Click(object sender, EventArgs e)
        {
            player = new PlayerMP(SettingsName_textBox.Text, null, GetRandomUnusedPort());

            GameServer gameServer = new GameServer(int.Parse(HostPort_textBox.Text));
            gameClient = new GameClient(gameForm, player, GetLocalIP(), int.Parse(HostPort_textBox.Text));

            Packet00Login loginPacket = new Packet00Login(player.username, player.port.ToString());
            loginPacket.WriteData(gameClient);

            loginForm.Hide();
            gameForm.Show();
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

        public static void CloseForm()
        {
            Packet01Disconnect disconnectPacket = new Packet01Disconnect(player.username);
            disconnectPacket.WriteData(gameClient);
            loginForm.Close();
        }
    }
}