using System.Collections.Generic;

namespace MCBot.Resources.Datatypes
{
    public class Settings
    {
        public string token { get; set; }
        public ulong owner { get; set; }
        public List<ulong> log { get; set; }
        public string version { get; set; }
        public List<ulong> banned { get; set; }
        public string defaultServer { get; set; }
    }

    public class MCServerData
    {
        public class BaseMCData
        {
            public string ip { get; set; }
            public int port { get; set; }
            public Debug debug { get; set; }
            public Motd motd { get; set; }
            public Players players { get; set; }
            public string version { get; set; }
            public bool online { get; set; }
            public int protocol { get; set; }
        }

        public class Debug
        {
            public bool ping { get; set; }
            public bool query { get; set; }
            public bool srv { get; set; }
            public bool querymismatch { get; set; }
            public bool ipinsrv { get; set; }
            public bool animatedmotd { get; set; }
            public bool proxypipe { get; set; }
            public int cachetime { get; set; }
            public int api_version { get; set; }
        }

        public class Motd
        {
            public string[] raw { get; set; }
            public string[] clean { get; set; }
            public string[] html { get; set; }
        }

        public class Players
        {
            public int online { get; set; }
            public int max { get; set; }
            public string[] list { get; set; }
        }

    }
}
