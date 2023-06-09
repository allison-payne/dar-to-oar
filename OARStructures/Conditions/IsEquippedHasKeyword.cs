﻿using DARtoOAR.OARStructures.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DARtoOAR.OARStructures.Conditions
{
    internal class IsEquippedHasKeyword: Condition
    {
        public KeywordValue? Keyword { get; set; }
        [JsonPropertyName("Left hand")]
        public bool leftHand { get; set; }
    }
}
