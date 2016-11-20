using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamControllerDBClient
{
    public class ConfigFile
    {
        public string GameName { get; set; }
        public long? SteamAppId { get; set; }
        public long? SteamConfigId { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConfigData { get; set; }
    }
}
