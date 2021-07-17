using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCCS.Ngrok
{
    public class TunnelsInfo
    {
        [JsonProperty("tunnels")]
        public List<Tunnel> Tunnels { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
