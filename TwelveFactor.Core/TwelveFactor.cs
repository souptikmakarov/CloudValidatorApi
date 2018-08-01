using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.Extensions;
using TwelveFactor.Core.Factors;
using TwelveFactor.Core.Factory;
using TwelveFactor.Core.Interface;
using TwelveFactor.Core.Models;
using TwelveFactor.Core.ViewModel;

namespace TwelveFactor.Core
{
    public class TwelveFactor
    {
        private readonly string _application;
        private readonly string _folderName;
        private readonly List<TwelveFactorResponseVm> _twelveFactorResponse = new List<TwelveFactorResponseVm>();

        public TwelveFactor(string application, string folderName)
        {
            _application = application;
            _folderName = folderName;
        }
        
        public List<TwelveFactorResponseVm> DoValidation(List<Factor> factors)
        {
            factors.ForEach(fact =>
            {
                if (fact == Factor.Logs)
                    _twelveFactorResponse.Add(new LogsFactory(_application, _folderName)
                        .InclusiveConditions(fact.GetRulesBasedOnFactor(_application, RuleType.Include))
                        .ExclusiveConditions(fact.GetRulesBasedOnFactor(_application, RuleType.Exclude)).EmitResponse()); 
                else if (fact == Factor.Config)
                {
                    _twelveFactorResponse.Add(new ConfigFactor(_application, _folderName)
                        .InclusiveConditions(fact.GetRulesBasedOnFactor(_application, RuleType.Include))
                        .ExclusiveConditions(fact.GetRulesBasedOnFactor(_application, RuleType.Exclude)).EmitResponse());
                }
                else if (fact == Factor.Backing)
                {
                    _twelveFactorResponse.Add(new BackingServiceFactor(_application, _folderName)
                        .InclusiveConditions(fact.GetRulesBasedOnFactor(_application, RuleType.Include))
                        .ExclusiveConditions(fact.GetRulesBasedOnFactor(_application, RuleType.Exclude)).EmitResponse());
                }
            });

            return _twelveFactorResponse;
        }
    }
}
