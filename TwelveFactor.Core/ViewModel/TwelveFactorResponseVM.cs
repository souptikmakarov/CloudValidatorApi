using System;
using System.Collections.Generic;
using System.Text;

namespace TwelveFactor.Core.ViewModel
{
    public class TwelveFactorResponseVm
    {
        public string Application { get; set; }
        public string FactorName { get; set; }
        //public string FileName { get; set; }
        public List<RuleResponseVm> ResponseInfo{ get; set; }
    }
}
