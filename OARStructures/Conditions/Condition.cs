using System.Text.Json.Serialization;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class Condition
    {
        public string? condition { get; set; }
        public string? requiredVersion { get; set; }
        public bool? negated { get; set; }
    }
}
