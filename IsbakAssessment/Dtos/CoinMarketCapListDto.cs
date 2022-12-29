using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IsbakAssessment.Dtos
{
    public class CoinMarketCapListDto
    {
        public List<DataItem> Data { get; set; }
    }

    public class DataItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("quote")]
        public Quote Quote { get; set; }
    }

    public class Quote
    {
        [JsonProperty("TRY")]
        public QuoteItem Try { get; set; }
    }

    public class QuoteItem
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_change_24h")]
        public decimal VolumeChange24h { get; set; }

        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1h { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        public decimal PercentChange7d { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
