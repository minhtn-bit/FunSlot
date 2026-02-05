using System.Text.Json.Serialization;

namespace FunSlot
{


    public class ReelConfig
    {
        [JsonPropertyName("reelIdx")]
        public int reelIdx { get; set; }
        [JsonPropertyName("perConfig")]
        public int[]? perConfig { get; set; }
    }
    public class Configs
    {
        [JsonPropertyName("reelConfigs")]
        public ReelConfig[]? reelConfigs
        {
            get; set;
        }
        [JsonPropertyName("baseReel")]
        public string[][]? baseReel { get; set; }


    }


}