using DARtoOAR.OARStructures.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class CompareValues:Condition
    {
        [JsonPropertyName("Value A")]
        public object? valueA { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Value B")]
        public NumericValue? valueB { get; set; }
    }
}
