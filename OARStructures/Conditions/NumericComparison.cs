using System.Text.Json.Serialization;
using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class NumericComparison: Condition
    {
        public string? Comparison { get; set; }
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }
    }
}
