using DARtoOAR.OARStructures.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class HasSpell : Condition
    {
        public PluginValue? Spell { get; set; }
    }
}
