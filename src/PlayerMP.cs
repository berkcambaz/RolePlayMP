using RolePlayMP.src.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RPG.src
{
    public class PlayerMP
    {
        public String username;
        public String ipAddress;
        public int port;

        public Inventory inventory;
        public int roomNumber;
        public int health;
        public int armor;
        public int gold;

        public PlayerMP(String username, String ipAddress, int port, int roomNumber)
        {
            this.username = username;
            this.ipAddress = ipAddress;
            this.port = port;

            inventory = new Inventory();
            this.roomNumber = roomNumber;
            health = 5;     // Test
            armor = 5;      // Test
            gold = 10;      // Test
        }
    }
}
