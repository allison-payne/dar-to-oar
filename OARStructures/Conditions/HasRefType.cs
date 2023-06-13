using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class HasRefType : Condition
    {
        [JsonPropertyName("Location ref type")]
        public PluginValue? LocationRefType { get; set; }
    }
}
