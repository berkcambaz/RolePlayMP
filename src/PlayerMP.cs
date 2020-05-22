using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RPG.src
{
    class PlayerMP
    {
        public String username;
        public String ipAddress;
        public int port;

        public PlayerMP(String username, String ipAddress, int port)
        {
            this.username = username;
            this.ipAddress = ipAddress;
            this.port = port;
        }
    }
}
