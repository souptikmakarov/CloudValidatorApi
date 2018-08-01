using System;
using System.Collections.Generic;
using System.Text;
using TwelveFactor.Core.Enums;

namespace TwelveFactor.Core.Models
{
    public class Rules
    {
        public string RuleName { get; set; }
        public RuleType RuleType { get; set; }
        public Dictionary<Condition, object> Conditions { get; set; }

    }
}
