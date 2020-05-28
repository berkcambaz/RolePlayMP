using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayMP.src
{
    class Packet04RoundEnd : Packet
    {
        private String username;
        private String destination;

        public Packet04RoundEnd(byte[] data) : base(04)
        {
            String[] dataArr = ReadData(data).Split(',');
            username = dataArr[0];
            destination = dataArr[1];
        }

        public Packet04RoundEnd(String username, String destinationID) : base(04)
        {
            this.username = username;
            this.destination = destinationID;
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
            return Encoding.UTF8.GetBytes("04" + username + "," + destination);
        }

        public String GetUsername()
        {
            return username;
        }

        public String GetDestination()
        {
            return destination;
        }
    }
}
