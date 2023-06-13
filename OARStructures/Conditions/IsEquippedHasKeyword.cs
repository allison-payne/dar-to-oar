using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsEquippedHasKeyword: Condition
    {
        public KeywordValue? Keyword { get; set; }
        [JsonPropertyName("Left hand")]
        public bool leftHand { get; set; }
    }
}
