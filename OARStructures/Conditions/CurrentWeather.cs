using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class CurrentWeather : Condition
    {
        public PluginValue? Weather { get; set; }
    }
}
