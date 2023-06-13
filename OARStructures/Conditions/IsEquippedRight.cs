using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsEquippedRight :Condition
    {
        public PluginValue? Form { get; set; }

        IsEquippedRight()
        {
            this.condition = "IsEquippedRight";
        }
    }
}
