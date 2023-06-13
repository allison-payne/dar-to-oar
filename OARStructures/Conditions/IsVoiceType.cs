using oar_explorer.OARStructures.Values;
using System.Text.Json.Serialization;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsVoiceType : Condition
    {
        [JsonPropertyName("Voice type")]
        public PluginValue? VoiceType { get; set; }
    }
}
