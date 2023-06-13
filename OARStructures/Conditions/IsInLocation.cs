using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsInLocation : Condition
    {
        public PluginValue? Location { get; set; }
    }
}
