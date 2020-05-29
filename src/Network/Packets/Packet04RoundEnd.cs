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
        private String itemIndex;

        public Packet04RoundEnd(byte[] data) : base(04)
        {
            String[] dataArr = ReadData(data).Split(',');
            username = dataArr[0];
            destination = dataArr[1];
            itemIndex = dataArr[2];
        }

        public Packet04RoundEnd(String username, String destinationID, String itemIndex) : base(04)
        {
            this.username = username;
            this.destination = destinationID;
            this.itemIndex = itemIndex;
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
            return Encoding.UTF8.GetBytes("04" + username + "," + destination + "," + itemIndex);
        }

        public String GetUsername()
        {
            return username;
        }

        public String GetDestination()
        {
            return destination;
        }

        public String GetItemIndex()
        {
            return itemIndex;
        }
    }
}
