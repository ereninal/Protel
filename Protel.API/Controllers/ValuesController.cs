using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Protel.Business.Interface;
using Protel.Core.Security;
using Protel.DataAccess.Repository.Interface;
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
        private readonly ICurrencyTypeBusiness ICurrencyTypeBusiness;
        private readonly ICurrencyInfoBusiness ICurrencyInfoBusiness;

        public ValuesController(ICurrencyTypeBusiness _ICurrencyTypeBusiness, ICurrencyInfoBusiness _ICurrencyInfoBusiness)
        {
            ICurrencyTypeBusiness = _ICurrencyTypeBusiness;
            ICurrencyInfoBusiness = _ICurrencyInfoBusiness;
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
        [HttpPost("AddCurrencyTypes")]
        public async Task<ApiResponse> AddCurrencyTypes()
        {
            return await ICurrencyTypeBusiness.AddRange();
        }
        [HttpPost("DailyCurrencyInfo")]
        public async Task<ApiResponse> DailyCurrencyInfo()
        {
            return await ICurrencyInfoBusiness.AddRangeByDaily();
        }
    }
}
