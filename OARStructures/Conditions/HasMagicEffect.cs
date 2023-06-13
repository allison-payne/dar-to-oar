using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class HasMagicEffect : Condition
    {
        [JsonPropertyName("Magic effect")]
        public PluginValue magicEffect { get; set; }
    }
}
