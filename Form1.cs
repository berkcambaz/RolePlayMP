using RolePlayMP.src;
using RPG.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class Form1 : Form
    {
        private static GameServer gameServer;
        private static GameClient gameClient;
        private static PlayerMP player;

        private static Form1 loginForm;
        private static Form2 gameForm;

        public Form1()
        {
            InitializeComponent();

            ListBox.CheckForIllegalCrossThreadCalls = false;

            loginForm = this;
        }

        private void Join_button_Click(object sender, EventArgs e)
        {
            player = new PlayerMP(SettingsName_textBox.Text, null, GetRandomUnusedPort(), 0);

            gameForm = new Form2();

            gameClient = new GameClient(gameForm, ref player, JoinIP_textBox.Text, int.Parse(JoinPort_textBox.Text));

            Packet00Login loginPacket = new Packet00Login(player.username, player.port.ToString());
            loginPacket.WriteData(gameClient);

            gameForm.Countdown_label.Visible = true;
            loginForm.Hide();
            gameForm.Show();
        }

        private void Host_button_Click(object sender, EventArgs e)
        {
            player = new PlayerMP(SettingsName_textBox.Text, null, GetRandomUnusedPort(), 0);

            gameForm = new Form2();

            gameServer = new GameServer(int.Parse(HostPort_textBox.Text));
            gameClient = new GameClient(gameForm, ref player, GetLocalIP(), int.Parse(HostPort_textBox.Text));

            Packet00Login loginPacket = new Packet00Login(player.username, player.port.ToString());
            loginPacket.WriteData(gameClient);

            gameForm.Countdown_button.Visible = true;
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

        public static GameServer GetGameServer()
        {
            return gameServer;
        }

        public static GameClient GetGameClient()
        {
            return gameClient;
        }

        public static ref PlayerMP GetPlayerMP()
        {
            return ref player;
        }

        public static void CloseForm()
        {
            Packet01Disconnect disconnectPacket = new Packet01Disconnect(player.username);
            disconnectPacket.WriteData(gameClient);
            loginForm.Close();
        }
    }
}