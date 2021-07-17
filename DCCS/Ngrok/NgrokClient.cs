using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DCCS.Ngrok
{
    public class NgrokClient
    {
        const string Uri = "http://localhost:4040/api/tunnels";

        public async Task<TunnelsInfo> GetInfo()
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage response = await http.GetAsync(Uri);
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TunnelsInfo>(content);
            }
        }

        public Tunnel GetFirstHttpsTunnel()
        {
            return this.GetInfo().Result.Tunnels.Where(t => t.Protocol.Equals("https")).FirstOrDefault();
        }
    }
}
