using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class OR : Condition
    {
        public List<Condition> conditions { get; set; } = new List<Condition>();

        public OR()
        {
            this.condition = "OR";
        }
    }
}
