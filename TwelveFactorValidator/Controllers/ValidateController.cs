using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwelveFactor.Core;
using TwelveFactor.Core.Enums;
using TwelveFactor.Core.ViewModel;
using TwelveFactorValidator.Models;

namespace TwelveFactorValidator.Controllers
{
    [Route("api/[controller]")]
    public class ValidateController : Controller
    {
        [HttpPost]
        public List<TwelveFactorResponseVm> Index([FromBody]ValidateRequest request)
        {
            var twelveFactorInstance = new TwelveFactor.Core.TwelveFactor(request.Application, request.FolderName);
            return twelveFactorInstance.DoValidation(request.Factors);
        }
    }




}