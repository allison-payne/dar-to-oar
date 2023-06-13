using System.Text.Json.Serialization;
using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class RandomCondition : Condition
    {
        [JsonPropertyName("Random value")]
        public RandomValue? randomValue { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }

        public bool keepRandomResultsOnLoop { get; set; } = true;
    }
}
