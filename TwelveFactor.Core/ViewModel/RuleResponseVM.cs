using System;
using System.Collections.Generic;
using System.Text;
using TwelveFactor.Core.Enums;

namespace TwelveFactor.Core.ViewModel
{
    public class RuleResponseVm
    {
        public string FileName { get; set; }
        public string RuleName { get; set; }
        public string RuleType { get; set; }
        public bool RuleStatus { get; set; }
        public Dictionary<Condition, object> Conditons { get; set; }
        public Dictionary<Condition, object> ValidationDetailedInfo { get; set; }
        public Dictionary<Condition, object> Recommendations { get; set; }
    }
}
