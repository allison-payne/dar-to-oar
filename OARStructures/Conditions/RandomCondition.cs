using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DARtoOAR.OARStructures.Values;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class RandomCondition : Condition
    {
        [JsonPropertyName("Random value")]
        public RandomValue? randomValue { get; set; }
        public string? Comparison { get; set; }
        [JsonPropertyName("Numeric value")]
        public NumericValue? numericValue { get; set; }

        public bool keepRandomResultsOnLoop { get; set; } = true;
    }
}
