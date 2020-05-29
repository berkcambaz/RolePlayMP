using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayMP.src
{
    class Packet03RoundStart : Packet
    {
        public Packet03RoundStart() : base(03) { }

        public override void WriteData(GameClient client)
        {
            client.SendData(GetData());
        }

        public override void WriteData(GameServer server)
        {
            server.SendDataToAllClientsNotServer(GetData());
        }

        public override byte[] GetData()
        {
            return Encoding.UTF8.GetBytes("03");
        }
    }
}
