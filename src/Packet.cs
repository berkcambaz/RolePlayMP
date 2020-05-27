using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    abstract class Packet
    {
        public enum PacketTypes
        {
            INVALID = -1,
            LOGIN = 00,
            DISCONNECT = 01
        }

        public byte packetId;

        public Packet(int packetId)
        {
            this.packetId = (byte)packetId;
        }

        public abstract void WriteData(GameClient client);
        public abstract void WriteData(GameServer server);

        public String ReadData(byte[] data)
        {
            String dataStr = System.Text.ASCIIEncoding.UTF8.GetString(data).Replace("\0", "");
            return dataStr.Substring(2);
        }

        public abstract byte[] GetData();

        public static PacketTypes FindPacket(String id)
        {
            int result;
            bool isParsable = int.TryParse(id, out result);

            if (isParsable)
                return (PacketTypes)result;

            return PacketTypes.INVALID;
        }

        public static PacketTypes FindPacket(int id)
        {
            foreach (int packet in Enum.GetValues(typeof(PacketTypes)))
            {
                if (id == packet)
                {
                    return (PacketTypes)id;
                }
            }

            return PacketTypes.INVALID;
        }

    }
}
