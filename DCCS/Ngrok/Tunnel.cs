using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCCS.Ngrok
{
    public class Tunnel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("public_url")]
        public string PublicUrl { get; set; }

        [JsonProperty("proto")]
        public string Protocol { get; set; }

        [JsonProperty("config")]
        public TunnelConfiguration Configuration { get; set; }
    }
}
