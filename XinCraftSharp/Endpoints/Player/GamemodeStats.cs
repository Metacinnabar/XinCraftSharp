using Newtonsoft.Json;

namespace XinCraftSharp.Endpoints.Player
{
    public struct GamemodeStats
    {
        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("winstreak")]
        public int Winstreak { get; set; }

        [JsonProperty("bestWinstreak")]
        public int BestWinstreak { get; set; }
    }
}