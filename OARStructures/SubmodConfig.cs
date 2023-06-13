using oar_explorer.OARStructures.Conditions;
using System.Collections.Generic;

namespace oar_explorer.OARStructures
{
    internal class SubmodConfig
    {
        public string? name { get; set; }
        public string? description { get; set; } = "";
        public int? priority { get; set; }
        public string? overrideAnimationsFolder { get; set; } = "";
        public List<Condition>? conditions { get; set; }
    }
}
