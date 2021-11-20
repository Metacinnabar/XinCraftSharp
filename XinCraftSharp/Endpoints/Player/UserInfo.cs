using System.Collections.Generic;
using Newtonsoft.Json;
using XinCraftSharp.Core;

namespace XinCraftSharp.Endpoints.Player
{
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

        [JsonProperty("tokens")]
        public double Tokens { get; set; }

        [JsonProperty("stats")]
        public PlayerStats Stats { get; set; }

        [JsonProperty("favoritemaps")]
        public List<object> FavoriteMaps { get; set; }
    }
}