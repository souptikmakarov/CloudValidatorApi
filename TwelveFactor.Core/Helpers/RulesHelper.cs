using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwelveFactor.Core.Constants;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.Models;
using TwelveFactor.Core.ViewModel;
using TwelveFactor.Core.Extensions;

namespace TwelveFactor.Core.Helpers
{
    public static class RulesHelper
    {

        public static List<RuleResponseVm> CreateResponse(string extactFolderName, List<Rules> rules)
        {
            var rulesResponse = new List<RuleResponseVm>();
            var filePaths = Directory.GetFiles(ApplicationConstants.BaseFolderLocation + @"\" + extactFolderName + @"\").ToList();


            filePaths.ForEach(file =>
            {
                rules.ForEach(rule =>
                {
                    rulesResponse.Add(FileHelper.Validation(file, rule));
                });
            });

            return rulesResponse;
        }

        public static List<Rules> GetRulesBasedonFactor(Factor factor, string application, RuleType ruletype)
        {
            var fallback = JsonConvert.DeserializeObject(File.ReadAllText(ApplicationConstants.FallBackLocation));
            var result = (fallback as JArray).Children().Select(i => i).Where(i => i["Application"].ToString().Equals(application) && i["FactorType"].ToString().Equals(factor.ToString())).Select(a => a[ruletype.ToString()]).ToList();

            //var sss = (fallback as JArray).Children()
            //    .Where(i => i["Application"].ToString().Equals(application) &&
            //                i["FactorType"].ToString().Equals(factor.ToString())).ToList()
            //    .Select(a => new { IncludeRules = a["Include"] }).ToList();
            //var response = GenerateRules((fallback as JObject)?["DotNet"].Children()["Logs"].Children()["Include"].Children().ToList());

            var response = GenerateRules(result, ruletype);
            return response;
        }

        private static List<Rules> GenerateRules(List<JToken> rulesArray, RuleType ruletype)
        {
            List<Rules> ruleResponse = new List<Rules>();
            if (rulesArray != null)
            {
                ruleResponse = rulesArray.Children().Select(rule =>
                    new Rules()
                    {
                        RuleName = rule["RuleName"].ToString(),
                        RuleType = ruletype,
                        Conditions = (rule["RuleConditions"] as JArray)
                                    .Children<JObject>().Properties()
                                    .Select(a1 => new { Name = a1.Name.FromStringToEnum<Condition>(), Val = (object)a1.Value })
                                    .ToDictionary(a => a.Name, a => a.Val)
                    }

                )?.ToList();
            }

            return ruleResponse;
        }
    }
}
