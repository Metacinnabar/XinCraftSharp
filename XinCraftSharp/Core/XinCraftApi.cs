using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XinCraftSharp.Endpoints.Player;

namespace XinCraftSharp.Core
{

    public class XinCraftApi
    {
        public static readonly string BaseUrl = "https://xincraft.net/api/v1";
        private readonly HttpClient client;

        public XinCraftApi(string apiKey)
        {
            client = new HttpClient();
            ProductInfoHeaderValue userAgent = new("XinCraftSharp", "1.0.0");
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);
            client.DefaultRequestHeaders.Add("xincraft-api", apiKey);
        }

        public async Task<ApiResponse<UserInfo>> GetUserInfoFromUsername(string username, bool debug = false)
        {
            return await GetFromEndpoint<UserInfo>("/player/username/" + username, debug);
        }
        
        public async Task<ApiResponse<UserInfo>> GetUserInfoFromUuid(string uuid)
        {
            return await GetFromEndpoint<UserInfo>("/player/uuid/" + uuid);
        }

        private async Task<ApiResponse<T>> GetFromEndpoint<T>(string endpoint, bool debug = false) where T : IApiObject
        {
            string url = BaseUrl + endpoint;
            if (debug)
            {
                Console.WriteLine("[query] querying " + url);
                Console.WriteLine("[query] with headers:");
                foreach (var (key, value) in client.DefaultRequestHeaders)
                {
                    Console.WriteLine("[query] " + key + ": " + value.First());
                }
            }
            
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ApiResponse<T>>(json);
        }
    } 
}