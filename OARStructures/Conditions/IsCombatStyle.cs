using DARtoOAR.OARStructures.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class IsCombatStyle : Condition
    {
        [JsonPropertyName("Combat style")]
        public PluginValue? CombatStyle { get; set; }
    }
}
