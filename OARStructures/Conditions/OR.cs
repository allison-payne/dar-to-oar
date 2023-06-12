using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class OR : Condition
    {
        public object[] conditions { get; set; }

        public OR()
        {
            this.condition = "OR";
            this.conditions = new object[0];
        }
    }
}
