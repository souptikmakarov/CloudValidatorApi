using System;
using System.Collections.Generic;
using System.Text;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.Factors;
using TwelveFactor.Core.Interface;
using TwelveFactor.Core.Models;

namespace TwelveFactor.Core.Factory
{
    public class FactorCreation
    {
        private string FolderName{ get; set; }
   
        public FactorCreation(string folderName)
        {
            FolderName = folderName;
        }
        public IFactor GetFactor(Factor factor)
        {
            //if (factor is LogsFactory)
            //    return new LogsFactory(FolderName);
            //else if (factor is ConfigFactor)
            //    return new ConfigFactor(FolderName);
            //else if (factor is BackingServiceFactor)
            //    return new BackingServiceFactor(FolderName);

            return null;

        }
    }
}
