using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwelveFactor.Core.Enums;

namespace TwelveFactorValidator.Models
{
    public class ValidateRequest
    {
        public string Application { get; set; }
        public string FolderName { get; set; }
        public List<Factor> Factors { get; set; }
        
    }
}
