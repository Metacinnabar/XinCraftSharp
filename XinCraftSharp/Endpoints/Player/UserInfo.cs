using System.Collections.Generic;
using Newtonsoft.Json;
using XinCraftSharp.Core;

namespace XinCraftSharp.Endpoints.Player
{
    /// <summary>
    /// UserInfo object returned when querying the /player endpoint.
    /// </summary>
    public struct UserInfo : IApiObject
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rankcolor")]
        public string RankColor { get; set; }

        // Supposed to be hidden - Raymond
        [JsonProperty("tokens")]
        private double Tokens { get; set; }

        [JsonProperty("stats")]
        public PlayerStats Stats { get; set; }

        [JsonProperty("favoritemaps")]
        public List<object> FavoriteMaps { get; set; }
    }
}