using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class HasPerk : Condition
    {
        public PluginValue? Perk { get; set; }
    }
}
