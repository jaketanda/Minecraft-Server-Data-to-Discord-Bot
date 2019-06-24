using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MCBot.Resources.Extensions;

namespace MCBot.Resources.Datatypes
{
    class MCAPIDataProcessor
    {
        public static async Task<MCServerData.BaseMCData> LoadData(string Ip = "")
        {
            string url = APIHelper.APIClient.BaseAddress + Ip;

            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Checking data for server IP " + Ip);
                    MCServerData.BaseMCData data = await response.Content.ReadAsAsync<MCServerData.BaseMCData>();

                    return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
