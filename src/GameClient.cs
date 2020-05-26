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
        private TcpListener clientListener;

        private Handler handler;

        private String ipAddress;
        private int serverPort;
        public int ownPort;

        public GameClient(Handler handler, String ipAddress, int serverPort, int ownPort)
        {
            this.handler = handler;
            this.ipAddress = ipAddress;
            this.serverPort = serverPort;
            this.ownPort = ownPort;
            try
            {
                clientListener = new TcpListener(IPAddress.Any, ownPort); // Needs fix
                clientListener.Start();
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
                    TcpClient client = clientListener.AcceptTcpClient();
                    client.Client.Receive(data);

                    ParsePacket(data);
                    client.Close();
                }
                catch (Exception) { }
            }
        }

        public void ParsePacket(byte[] data)
        {
            String dataStr = System.Text.ASCIIEncoding.UTF8.GetString(data).Trim();
            Packet.PacketTypes type = Packet.FindPacket(dataStr.Substring(0, 2));
            switch (type)
            {
                case Packet.PacketTypes.INVALID:
                    break;
                case Packet.PacketTypes.LOGIN:
                    Packet00Login loginPacket = new Packet00Login(data);
                    handler.form2.label1.Text = loginPacket.GetUsername();
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
                TcpClient client = new TcpClient(ipAddress, serverPort);
                client.Client.Send(data);
                client.Close();
            }
            catch (Exception) { }
        }
    }
}
