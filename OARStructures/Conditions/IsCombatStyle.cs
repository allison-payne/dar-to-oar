using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsCombatStyle : Condition
    {
        [JsonPropertyName("Combat style")]
        public PluginValue? CombatStyle { get; set; }
    }
}
