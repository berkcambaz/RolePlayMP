using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Packet01Disconnect : Packet
    {
        private String username;

        public Packet01Disconnect(byte[] data) : base(01)
        {
            username = ReadData(data);
        }

        public Packet01Disconnect(String username) : base(01)
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
