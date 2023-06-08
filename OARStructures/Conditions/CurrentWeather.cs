using DARtoOAR.OARStructures.Values;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class CurrentWeather : Condition
    {
        public PluginValue? Weather { get; set; }
    }
}
