using DARtoOAR.OARStructures.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
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
