using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class MarketOverview
    {
        [JsonPropertyName("lastDataDEven")]
        public int? lastDataDEven { get; set; }

        [JsonPropertyName("lastDataHEven")]
        public int? lastDataHEven { get; set; }

        [JsonPropertyName("indexLastValue")]
        public double? indexLastValue { get; set; }

        [JsonPropertyName("indexChange")]
        public double? indexChange { get; set; }

        [JsonPropertyName("indexEqualWeightedLastValue")]
        public double? indexEqualWeightedLastValue { get; set; }

        [JsonPropertyName("indexEqualWeightedChange")]
        public double? indexEqualWeightedChange { get; set; }

        [JsonPropertyName("marketActivityDEven")]
        public int? marketActivityDEven { get; set; }

        [JsonPropertyName("marketActivityHEven")]
        public int? marketActivityHEven { get; set; }

        [JsonPropertyName("marketActivityZTotTran")]
        public int? marketActivityZTotTran { get; set; }

        [JsonPropertyName("marketActivityQTotCap")]
        public double? marketActivityQTotCap { get; set; }

        [JsonPropertyName("marketActivityQTotTran")]
        public double? marketActivityQTotTran { get; set; }

        [JsonPropertyName("marketState")]
        public string marketState { get; set; }

        [JsonPropertyName("marketValue")]
        public double? marketValue { get; set; }

        [JsonPropertyName("marketValueBase")]
        public double? marketValueBase { get; set; }

        [JsonPropertyName("marketStateTitle")]
        public string marketStateTitle { get; set; }
    }

    public class RootMarket
    {
        [JsonPropertyName("marketOverview")]
        public MarketOverview marketOverview { get; set; }
    }
}
