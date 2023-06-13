using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class IsEquippedLeft :Condition
    {
        public PluginValue? Form { get; set; }

        IsEquippedLeft()
        {
            this.condition = "IsEquippedLeft";
        }
    }
}
