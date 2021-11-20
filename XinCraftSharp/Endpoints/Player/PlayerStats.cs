using Newtonsoft.Json;

namespace XinCraftSharp.Endpoints.Player
{
    /// <summary>
    /// Statistics of the player including overall, solos, doubles, threes and fours.
    /// </summary>
    public struct PlayerStats
    {
        [JsonProperty("overall")]
        public GamemodeStats Overall { get; set; }

        [JsonProperty("solos")]
        public GamemodeStats Solos { get; set; }

        [JsonProperty("doubles")]
        public GamemodeStats Doubles { get; set; }

        [JsonProperty("threes")]
        public GamemodeStats Threes { get; set; }

        [JsonProperty("fours")]
        public GamemodeStats Fours { get; set; }
    }
}