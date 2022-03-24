using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Protel.Core.Security;
using Protel.Service.TCMB.Interface;
using Protel.Service.TCMB.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITCMBService ITCMBService;
        public ValuesController(ITCMBService _ITCMBService)
        {
            ITCMBService = _ITCMBService;
        }
        [HttpPost("GetEncrypt")]
        public string GetEncrypt(string param)
        {
            return param.Encrypt();
        }
        [HttpPost("GetDecrypt")]
        public string GetDecrypt(string param)
        {
            return param.Decrypt();
        }
        [HttpPost("GetInfo")]
        public async Task<ApiResponse> GetInfo(string param)
        {
            return await ITCMBService.GetDailyCurrencyInfos();
        }
    }
}
