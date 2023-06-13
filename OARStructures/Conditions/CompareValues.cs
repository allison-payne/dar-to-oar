using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class CompareValues : Condition
    {
        [JsonPropertyName("Value A")]
        public object? valueA { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Value B")]
        public object? valueB { get; set; }
    }
}
