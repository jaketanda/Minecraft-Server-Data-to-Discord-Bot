using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MCBot.Resources.Extensions
{
    public static class APIHelper
    {
        public static HttpClient APIClient { get; set; }
        
        public static void InitializeClient()
        {
            APIClient = new HttpClient();
            APIClient.BaseAddress = new Uri("https://api.mcsrvstat.us/2/");
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
