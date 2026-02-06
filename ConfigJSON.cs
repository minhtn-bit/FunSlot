using System.Text.Json.Serialization;

namespace FunSlot
{
    public record Symbols
    {
        [JsonPropertyName("code")]
        public string code { get; set; }

        [JsonPropertyName("paytable")]
        public int[] paytable { get; set; }
    }
    public record ReelConfig
    {
        [JsonPropertyName("reelIdx")]
        public int reelIdx { get; set; }

        [JsonPropertyName("perConfig")]
        public int[]? perConfig { get; set; }
    }
    public record Configs
    {
        [JsonPropertyName("symbols")]
        public Symbols[] symbols { get; set; }

        [JsonPropertyName("reelConfigs")]
        public ReelConfig[]? reelConfigs { get; set; }

        [JsonPropertyName("baseReel")]
        public string[][]? baseReel { get; set; }
    }


}