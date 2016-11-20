using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamControllerDBClient
{
    public class SteamApp
    {
        public ulong AppId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
