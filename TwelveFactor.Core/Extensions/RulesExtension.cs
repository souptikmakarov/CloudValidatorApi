using System;
using System.Collections.Generic;
using System.Text;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.Helpers;
using TwelveFactor.Core.Models;
using TwelveFactor.Core.ViewModel;

namespace TwelveFactor.Core.Extensions
{
    public static class RulesExtension
    {

        public static List<RuleResponseVm> CreateResponse(this List<Rules> rules, string folderName)
        {
            return RulesHelper.CreateResponse(folderName, rules);
        }

        public static List<Rules> GetRulesBasedOnFactor(this Factor factor, string application, RuleType rule)
        {
            return RulesHelper.GetRulesBasedonFactor(factor, application, rule);
        }

        public static T FromStringToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

    }
}
