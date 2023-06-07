using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DARtoOAR.OARStructures.Values;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class NumericComparison: Condition
    {
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }
    }
}
