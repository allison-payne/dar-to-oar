using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsEquipped: Condition
    {
        // TODO Verify Property Name
        public PluginValue? Form { get; set; }
        [JsonPropertyName("Left hand")]
        public bool leftHand { get; set; }
    }
}
