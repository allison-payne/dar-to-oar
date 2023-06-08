using DARtoOAR.OARStructures.Values;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class IsInFaction : Condition
    {
        public PluginValue? Faction { get; set; }
    }
}
