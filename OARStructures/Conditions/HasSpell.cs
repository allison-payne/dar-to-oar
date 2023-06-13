using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class HasSpell : Condition
    {
        public PluginValue? Spell { get; set; }
    }
}
