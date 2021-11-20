using Newtonsoft.Json;

namespace XinCraftSharp.Core
{
    /// <summary>
    /// Used for every response from the API.
    /// </summary>
    /// <typeparam name="T">The API object deriving from IApiObject</typeparam>
    public struct ApiResponse<T> where T : IApiObject
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
        
        [JsonProperty("cause")]
        public string Cause { get; set; }
    }
}