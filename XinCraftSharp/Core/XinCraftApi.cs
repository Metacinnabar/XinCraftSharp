using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XinCraftSharp.Endpoints.Player;

namespace XinCraftSharp.Core
{
    /// <summary>
    /// Main API class where endpoints are accessed from.
    /// </summary>
    public class XinCraftApi
    {
        /// <summary>
        /// Base URL for all requests.
        /// </summary>
        public static readonly string BaseUrl = "https://xincraft.net/api/v1";
        
        /// <summary>
        /// HttpClient used with every request. Headers initialized in ctor.
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// An automatically-created <see cref="RequestBucket"/> attributed to this object instance. <br />
        /// Handles ratelimiting, it is unwise to instantiate a second instance in order to attempt to bypass this.
        /// </summary>
        public RequestBucket Bucket { get; }

        public XinCraftApi(string apiKey)
        {
            // Initialise the HttpClient.
            client = new HttpClient();
            // Add our UserAgent to the client, to be used with each request.
            ProductInfoHeaderValue userAgent = new("XinCraftSharp", "1.0.0");
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);
            // Add the API key header to each request.
            client.DefaultRequestHeaders.Add("xincraft-api", apiKey);

            // Start count-down upon object creation.
            Bucket = new RequestBucket(
                100,
                100,
                TimeSpan.FromMinutes(1),
                DateTime.UtcNow.Add(TimeSpan.FromMinutes(1))
            );
        }

        /// <summary>
        /// Get an ApiResponse of a UserInfo object from username.
        /// </summary>
        /// <param name="username">The username used to lookup information.</param>
        /// <param name="debug">Boolean to print debug text in console.</param>
        /// <returns>Returns the API response object of UserInfo.</returns>
        public async Task<ApiResponse<UserInfo>> GetUserInfoFromUsername(string username, bool debug = false)
        {
            return await GetFromEndpoint<UserInfo>("/player/username/" + username, debug);
        }
        
        /// <summary>
        /// Get an ApiResponse of a UserInfo object from uuid.
        /// </summary>
        /// <param name="uuid">The dashed uuid used to lookup information.</param>
        /// <param name="debug">Boolean to print debug text in console.</param>
        /// <returns>Returns the API response object of UserInfo.</returns>
        public async Task<ApiResponse<UserInfo>> GetUserInfoFromUuid(string uuid, bool debug = false)
        {
            return await GetFromEndpoint<UserInfo>("/player/uuid/" + uuid, debug);
        }

        /// <summary>
        /// Get an API response from a provided endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint to query data from.</param>
        /// <param name="debug">Boolean to print debug information to console.</param>
        /// <typeparam name="T">IApiObject derived type to parse the data into. </typeparam>
        /// <returns>Returns an API response object of the provided type.</returns>
        private async Task<ApiResponse<T>> GetFromEndpoint<T>(string endpoint, bool debug = false) where T : IApiObject
        {
            // Acquire from the bucket. Pauses and waits if ratelimited.
            await Bucket.Acquire();

            // Create a local variable to ease grabbing the url.
            string url = BaseUrl + endpoint;
            
            // Check if debug is true.
            if (debug)
            {
                // Print debug information of the url.
                Console.WriteLine("[query] querying " + url);
                // Print debug information of the headers.
                Console.WriteLine("[query] with headers:");
                // Print each header on a newline.
                foreach (var (key, value) in client.DefaultRequestHeaders)
                    Console.WriteLine("[query] " + key + ": " + value.First());
            }

            // Send request to the client and parse the headers for ratelimiting.
            using HttpResponseMessage response = await client.GetAsync(url);
            await Bucket.ParseHeaders(response.Headers);
            
            // Query the endpoint and assign the API response to a local variable.
            string json = await response.Content.ReadAsStringAsync();
            // Return a parsed JSON string into our provided type argument.
            return JsonConvert.DeserializeObject<ApiResponse<T>>(json);
        }
    } 
}