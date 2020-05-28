using RolePlayMP.src;
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
    public class GameServer
    {
        private LinkedList<PlayerMP> connectedPlayers = new LinkedList<PlayerMP>();
        private TcpListener server;

        public GameServer(int port)
        {
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

                    String clientIPAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                    ParsePacket(data, clientIPAddress);
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
                case Packet.PacketTypes.MESSAGE:
                    SendDataToAllClients(data); // Send the message to all clients
                    break;
                case Packet.PacketTypes.ROUND_START:
                    SendDataToAllClients(data);
                    break;
            }
        }

        public void AddConnection(PlayerMP player, Packet00Login loginPacket)
        {
            // Check if the same player name is used by another user
            foreach (PlayerMP p in connectedPlayers)
            {
                if (p.username.Equals(loginPacket.GetUsername()))
                {
                    return;
                }
            }

            // If not used, send & receive data
            foreach (PlayerMP p in connectedPlayers)
            {
                // Send newly connected player's data to already connected players
                SendData(loginPacket.GetData(), p.ipAddress, p.port);
                // Send already connected players' data to newly connected player
                SendData(new Packet00Login(p.username).GetData(), player.ipAddress, player.port);
            }

            connectedPlayers.AddLast(player);
            SendData(loginPacket.GetData(), player.ipAddress, player.port);
        }

        public void RemoveConnection(Packet01Disconnect disconnectPacket)
        {
            connectedPlayers.Remove(GetPlayerMPNode(disconnectPacket.GetUsername()));
            disconnectPacket.WriteData(this);
        }

        private PlayerMP GetPlayerMPNode(String username)
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
                TcpClient client = new TcpClient();
                client.Connect(ipAddress, port);
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