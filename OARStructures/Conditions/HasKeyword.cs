using oar_explorer.OARStructures.Values;

namespace oar_explorer.OARStructures.Conditions
{
    internal class HasKeyword : Condition
    {
        public KeywordValue? Keyword { get; set; }
    }
}
