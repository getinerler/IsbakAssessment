using Newtonsoft.Json;

namespace IsbakAssessment.Dtos
{
    public class CryptoModel
    {
        [JsonProperty("symbol")]
        public string  Symbol { get; set; }

        [JsonProperty("bidQty")]
        public decimal BidQty { get; set; }

        [JsonProperty("askPrice")]
        public decimal AskPrice { get; set; }

        [JsonProperty("askQty")]
        public decimal AskQty { get; set; }
    }
}
