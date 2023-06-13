namespace oar_explorer.OARStructures.Conditions
{
    internal class OR : Condition
    {
        public object[] Conditions { get; set; }

        public OR()
        {
            this.condition = "OR";
            this.Conditions = new object[0];
        }
    }
}
