using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RPG.src
{
    class GameClient
    {
        private TcpClient client;

        public GameClient(String ipAddress, int port)
        {
            try
            {
                client = new TcpClient(ipAddress, port);
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
                byte[] data = new byte[1024];
                try
                {
                    client.Client.Receive(data);

                    String ipAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    int port = ((IPEndPoint)client.Client.RemoteEndPoint).Port;

                    ParsePacket(data, ipAddress, port);
                }
                catch (Exception) { }
                Thread.Sleep(100);
            }
        }

        public void ParsePacket(byte[] data, String ipAddress, int port)
        {
            String dataStr = System.Text.ASCIIEncoding.UTF8.GetString(data).Trim();
            Packet.PacketTypes type = Packet.FindPacket(dataStr.Substring(0, 2));
            switch (type)
            {
                case Packet.PacketTypes.INVALID:
                    break;
                case Packet.PacketTypes.LOGIN:
                    Packet00Login loginPacket = new Packet00Login(data);
                    // Handle login
                    break;
                case Packet.PacketTypes.DISCONNECT:
                    Packet01Disconnect disconnectPacket = new Packet01Disconnect(data);
                    // Handle disconnect
                    break;
            }
        }

        public void SendData(byte[] data)
        {
            try
            {
                client.Client.Send(data);
            }
            catch (Exception) { }
        }
    }
}
