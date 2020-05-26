using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RPG.src
{
    class GameServer
    {
        private LinkedList<PlayerMP> connectedPlayers = new LinkedList<PlayerMP>();
        private TcpListener server;

        private Handler handler;

        public GameServer(Handler handler, String ipAddress, int port)
        {
            this.handler = handler;
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                Thread thread = new Thread(new ThreadStart(Run));
                thread.IsBackground = true; // Thread closes when the windows are closed
                thread.Start();
            }
            catch (Exception) { }
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[1024];
                    TcpClient client = server.AcceptTcpClient();
                    client.Client.Receive(data);

                    String ipAddress = ((IPEndPoint)client.Client.LocalEndPoint).Address.ToString();

                    ParsePacket(data, ipAddress);
                    client.Close();
                }
                catch (Exception) { }
            }
        }

        public void ParsePacket(byte[] data, String ipAddress)
        {
            String dataStr = System.Text.ASCIIEncoding.UTF8.GetString(data).Trim();
            Packet.PacketTypes type = Packet.FindPacket(dataStr.Substring(0, 2));
            switch (type)
            {
                case Packet.PacketTypes.INVALID:
                    break;
                case Packet.PacketTypes.LOGIN:
                    Packet00Login loginPacket = new Packet00Login(data);
                    PlayerMP player = new PlayerMP(loginPacket.GetUsername(), ipAddress, int.Parse(loginPacket.GetPort()));
                    AddConnection(player, loginPacket);
                    break;
                case Packet.PacketTypes.DISCONNECT:
                    Packet01Disconnect disconnectPacket = new Packet01Disconnect(data);
                    RemoveConnection(disconnectPacket);
                    break;
            }
        }

        public void AddConnection(PlayerMP player, Packet00Login packet)
        {
            bool alreadyConnected = false;
            foreach (PlayerMP p in connectedPlayers)
            {
                if (String.Equals(player.username, p.username, StringComparison.OrdinalIgnoreCase))
                {
                    alreadyConnected = true;
                }
                else
                {
                    // Send newly connected player's data to already connected players
                    SendData(packet.GetData(), p.ipAddress, p.port);
                    // Send already connected players' data to newly connected player
                    SendData(new Packet00Login(p.username).GetData(), player.ipAddress, player.port);
                }
            }
            if (!alreadyConnected)
            {
                connectedPlayers.AddLast(player);
                //handler.form2.label1.Text = player.username;
            }
        }

        public void RemoveConnection(Packet01Disconnect packet)
        {
            connectedPlayers.Remove(GetPlayerMPNode(packet.GetUsername()));
            packet.WriteData(this);
        }

        public PlayerMP GetPlayerMPNode(String username)
        {
            foreach (PlayerMP p in connectedPlayers)
            {
                if (p.username.Equals(username))
                {
                    return p;
                }
            }
            return null;
        }

        public void SendData(byte[] data, String ipAddress, int port)
        {
            try
            {
                TcpClient client = new TcpClient(ipAddress, port);
                client.Client.Send(data);
                client.Client.Close();
            }
            catch (Exception) { }
        }

        public void SendDataToAllClients(byte[] data)
        {
            foreach (PlayerMP p in connectedPlayers)
            {
                SendData(data, p.ipAddress, p.port);
            }
        }
    }
}
