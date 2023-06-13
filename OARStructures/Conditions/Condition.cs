namespace oar_explorer.OARStructures.Conditions
{
    internal class Condition
    {
        private const string CONFIG_FILE_DEFAULT_VERSION = "1.0.0.0";
        public string? condition { get; set; }
        public string requiredVersion { get; set; } = CONFIG_FILE_DEFAULT_VERSION;
        public bool negated { get; set; } = false;
    }
}
