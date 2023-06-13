using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class FactionRank : Condition
    {
        public PluginValue? Faction { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }
    }
}
