using RPG.src;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RolePlayMP.src
{
    public static class Room
    {
        private static RoomEffect roomEffect;

        private static int roomNumber;
        private static String[] roomNames;
        private static String[] roomDestination;
        private static int[] roomEffectIndex;
        private static int[] roomEffectModifier;

        private static int currentRoom = 0;

        public static void InitMap()
        {
            roomEffect = new RoomEffect();
            // TODO: Error checking
            try
            {
                String[] mapFile = File.ReadAllLines("map.txt");    // TODO: Selectable maps
                roomNumber = int.Parse(mapFile[0]);

                roomNames = new String[roomNumber];
                roomDestination = new String[roomNumber];
                roomEffectIndex = new int[roomNumber];
                roomEffectModifier = new int[roomNumber];

                for (int i = 0; i < roomNumber; i++)
                {
                    String[] dataArr = mapFile[i + 1].Split(',');
                    int roomIndex = int.Parse(dataArr[0]);
                    roomNames[roomIndex] = dataArr[1];
                    roomEffectIndex[roomIndex] = int.Parse(dataArr[2]);
                    roomEffectModifier[roomIndex] = int.Parse(dataArr[3]);
                }

                for (int i = 0; i < roomNumber; i++)
                {
                    String[] dataArr = mapFile[i + 1 + roomNumber].Split('-');
                    roomDestination[int.Parse(dataArr[0])] = dataArr[1];
                }
            }
            catch (Exception) { }
        }

        public static void Effect(ref PlayerMP player)
        {
            roomEffect.Effect(ref player, roomEffectIndex[player.roomNumber], roomEffectModifier[player.roomNumber]);
        }

        public static String GetRoomName(int index)
        {
            return roomNames[index];
        }

        public static String GetRoomDestination(int index)
        {
            return roomDestination[index];
        }

        public static int GetRoomIndex(String roomName)
        {
            for (int i = 0; i < roomNumber; i++)
            {
                if (roomNames[i].Equals(roomName))
                {
                    return i;
                }
            }

            return 0;
        }

        public static int GetCurrentRoom()
        {
            return currentRoom;
        }

        public static void SetCurrentRoom(int roomNumber)
        {
            currentRoom = roomNumber;
        }
    }
}
