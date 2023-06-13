using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsInFaction : Condition
    {
        public PluginValue? Faction { get; set; }
    }
}
