using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamControllerDBClient
{
    public class SteamProfile
    {
        public SteamProfileResponse response { get; set; }
    }

    public class SteamProfileResponse
    {
        public List<SteamPlayer> players { get; set; }
    }

    public class SteamPlayer
    {
        public string steamid { get; set; }
        public string personaname { get; set; }
        public string id3 { get; set; }

        public override string ToString()
        {
            string result = id3;
            if(!string.IsNullOrWhiteSpace(personaname))
            {
                result += " (" + personaname + ")";
            }
            return result;
        }
    }
}
