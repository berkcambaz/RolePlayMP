using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    public class Packet00Login : Packet
    {
        private String username;
        private String port;

        public Packet00Login(byte[] data) : base(00)
        {
            String[] dataArr = ReadData(data).Split(',');
            username = dataArr[0];
            port = dataArr[1];
        }

        // Only for server sending data to client
        public Packet00Login(String username, String port) : base(00)
        {
            this.username = username;
            this.port = port;
        }

        public Packet00Login(String username) : base(00)
        {
            this.username = username;
        }

        public override void WriteData(GameClient client)
        {
            client.SendData(GetData());
        }

        public override void WriteData(GameServer server)
        {
            server.SendDataToAllClients(GetData());
        }

        public override byte[] GetData()
        {
            return Encoding.UTF8.GetBytes("00" + username + "," + port);
        }

        public String GetUsername()
        {
            return username;
        }

        public String GetPort()
        {
            return port;
        }
    }
}
