using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.Extensions;
using TwelveFactor.Core.Interface;
using TwelveFactor.Core.Models;
using TwelveFactor.Core.ViewModel;

namespace TwelveFactor.Core.Factors
{
    public class LogsFactory : IFactor
    {
        public List<RuleResponseVm> InclusiveCondition { get; set; }
        public List<RuleResponseVm> ExclusiveCondition { get; set; }
        public string FolderName { get; set; }
        public string Application { get; set; }

        public LogsFactory(string application, string folderName)
        {
            InclusiveCondition = new List<RuleResponseVm>();
            ExclusiveCondition = new List<RuleResponseVm>();
            Application = application;
            FolderName = folderName;
        }

        public IFactor InclusiveConditions(List<Rules> rules)
        {
            InclusiveCondition = rules.CreateResponse(FolderName);
            return this;
        }

        public IFactor ExclusiveConditions(List<Rules> rules)
        {
            ExclusiveCondition = rules.CreateResponse(FolderName);
            return this;
        }

        public TwelveFactorResponseVm EmitResponse()
        {
            var response = new TwelveFactorResponseVm
            {
                Application = Application,
                FactorName = Factor.Logs.ToString(),
                ResponseInfo = new List<RuleResponseVm>()
            };
            response.ResponseInfo.AddRange(InclusiveCondition);
            response.ResponseInfo.AddRange(ExclusiveCondition);
            return response;
        }
    }
}
