using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TwelveFactor.Core.Models;
using TwelveFactor.Core.ViewModel;

namespace TwelveFactor.Core.Interface
{
    public interface IFactor
    {
        List<RuleResponseVm> InclusiveCondition { get; set; }
        List<RuleResponseVm> ExclusiveCondition { get; set; }

        string FolderName { get; set; }
        string Application { get; set; }

        IFactor InclusiveConditions(List<Rules> rules);
        IFactor ExclusiveConditions(List<Rules> rules);

        TwelveFactorResponseVm EmitResponse();
    }

}
