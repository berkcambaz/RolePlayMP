using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayMP.src
{
    class Packet02Message : Packet
    {
        private String username;
        private String message;

        public Packet02Message(byte[] data) : base(02)
        {
            String[] dataArr = ReadData(data).Split(',');
            username = dataArr[0];
            message = dataArr[1];
        }

        public Packet02Message(String username, String message) : base(02)
        {
            this.username = username;
            this.message = message;
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
            return Encoding.UTF8.GetBytes("02" + username + "," + message);
        }

        public String GetUsername()
        {
            return username;
        }

        public String GetMessage()
        {
            return message;
        }
    }
}
