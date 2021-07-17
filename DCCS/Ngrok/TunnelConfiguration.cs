using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCCS.Ngrok
{
    public class TunnelConfiguration
    {
        [JsonProperty("addr")]
        public string Address { get; set; }

        [JsonProperty("inspect")]
        public bool Inspect { get; set; }
    }
}
