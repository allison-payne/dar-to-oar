using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsEquippedType:Condition
    {
        [JsonPropertyName("Type")]
        public TypeValue? typeValue { get; set; }
        [JsonPropertyName("Left hand")]
        public bool leftHand { get; set; }
    }
}
