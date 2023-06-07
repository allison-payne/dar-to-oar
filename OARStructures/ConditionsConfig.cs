using DARtoOAR.OARStructures.Conditions;

namespace DARtoOAR.OARStructures
{
    internal class ConditionsConfig
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public Int32? priority { get; set; }
        public string? overrideAnimationsFolder { get; set; }
        public object[]? conditions { get; set; }
    }
}
