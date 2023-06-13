using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsActorBase: Condition
    {
        [JsonPropertyName("Actor base")]
        public PluginValue? actorBase { get; set; }
    }
}
