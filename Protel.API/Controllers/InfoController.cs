using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Protel.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ICurrencyInfoBusiness ICurrencyInfoBusiness;

        public InfoController(ICurrencyInfoBusiness _ICurrencyInfoBusiness)
        {
            ICurrencyInfoBusiness = _ICurrencyInfoBusiness;
        }
        [HttpGet("AllCurrencies")]
        public async Task<ApiResponse> AllCurrencies()
        {
            return await ICurrencyInfoBusiness.GetCurrencyInfos();
        }
        [HttpGet("GetChangeByCurrency")]
        public async Task<ApiResponse> GetChangeByCurrency(string curreny="usd")
        {
            return await ICurrencyInfoBusiness.GetChangeByCurrency(curreny);
        }
    }
}
