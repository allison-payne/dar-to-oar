using System.Text.Json.Serialization;

namespace DARtoOAR.OARStructures
{
    internal class Condition
    {
        public string? condition { get; set; }
        public string? requiredVersion { get; set; } 
        public bool? negated { get; set; }
        [JsonPropertyName("Random value")]
        public RandomValue? randomValue { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }
    }
}
