using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamControllerDBClient
{
    public class SteamShortcut
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string SHA1 { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
