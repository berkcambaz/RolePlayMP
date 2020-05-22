using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Packet00Login : Packet
    {
        private String username;

        public Packet00Login(byte[] data) : base(00)
        {
            String[] dataArr = ReadData(data).Split(',');
            username = dataArr[0];
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
            return Encoding.ASCII.GetBytes("00" + username);
        }

        public String GetUsername()
        {
            return username;
        }
    }
}
