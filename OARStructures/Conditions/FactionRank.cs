using DARtoOAR.OARStructures.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class FactionRank : Condition
    {
        public PluginValue? Faction { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }
    }
}
