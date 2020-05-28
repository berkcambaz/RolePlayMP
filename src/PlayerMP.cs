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
        public int roomNumber;

        public PlayerMP(String username, String ipAddress, int port, int roomNumber)
        {
            this.username = username;
            this.ipAddress = ipAddress;
            this.port = port;
            this.roomNumber = roomNumber;
        }
    }
}
