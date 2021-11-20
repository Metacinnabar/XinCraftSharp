using Newtonsoft.Json;

namespace XinCraftSharp.Core
{
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