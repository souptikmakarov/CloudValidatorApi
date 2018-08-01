using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using TwelveFactor.Core.Constants;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.Models;
using TwelveFactor.Core.ViewModel;

namespace TwelveFactor.Core.Helpers
{
    public static class FileHelper
    {

        public static RuleResponseVm Validation(string fileName, Rules rules)
        {
            var validationDetailedInfo = new Dictionary<Condition, string>();
            var fileContent = File.ReadLines(fileName);
            var ruleStatus = true;
            var ruleResponseVm = new RuleResponseVm()
            {
                FileName = fileName,
                RuleName = rules.RuleName,
                RuleType = rules.RuleType.ToString(),
                Conditons = rules.Conditions,
                ValidationDetailedInfo = new Dictionary<Condition, object>(),
                Recommendations = new Dictionary<Condition, object>(),
            };

            foreach (var rule in rules.Conditions)
            {
                if (rule.Key.Equals(Enums.Condition.ContainsAny))
                {
                    var test = (rule.Value as JArray).Children();
                    var response = ContainsAll(fileContent, test.Select(a => a.Value<string>()).ToList());
                    ruleResponseVm.RuleStatus = response.Count != 0;
                    ruleResponseVm.ValidationDetailedInfo.Add(Condition.ContainsAny, response.Select(a => a.Item2));
                }
                else if (rule.Key.Equals(Enums.Condition.NotContainsAny))
                {
                    var test = (rule.Value as JArray).Children();
                    var response = NotContainsAll(fileContent, test.Select(a => a.Value<string>()).ToList());
                    ruleResponseVm.RuleStatus = !response.Select(a => a.Item1).Contains(false);
                    ruleResponseVm.ValidationDetailedInfo.Add(Condition.ContainsAny, response.Select(a => a.Item2));
                }
            }
            return ruleResponseVm;
        }

        private static List<Tuple<bool, string>> ContainsAll(IEnumerable<string> fileContent, List<string> searchTerms)
        {
            var listTuple = new List<Tuple<bool, string>>();
            //var res = new Tuple<bool, string>(false, string.Concat($"No Matches Found for Text:{searchTerms}"));

            searchTerms.ForEach(term =>
            {
                foreach (var match in fileContent.Select((text, index) => new { text, lineNumber = index + 1 }).Where(x => x.text.ToString().Contains(term)))
                {
                    var res = new Tuple<bool, string>(true, string.Concat("Matches Found @ Line Number " + match.lineNumber, " Text:" + match.text));
                    listTuple.Add(res);
                }
            });

            return listTuple;



        }
        private static List<Tuple<bool, string>> NotContainsAll(IEnumerable<string> fileContent, List<string> searchTerms)
        {
            var listTuple = new List<Tuple<bool, string>>();
            //var res = new Tuple<bool, string>(false, string.Concat($"No Matches Found for Text:{searchTerms}"));

            searchTerms.ForEach(term =>
            {
                foreach (var match in fileContent.Select((text, index) => new { text, lineNumber = index + 1 }).Where(x => x.text.ToString().Contains(term)))
                {
                    var res = new Tuple<bool, string>(false, string.Concat("Matches Found @ Line Number " + match.lineNumber, " Text:" + match.text));
                    listTuple.Add(res);
                }
            });

            return listTuple;
        }



    }
}
