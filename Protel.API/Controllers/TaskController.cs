using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Protel.Business.Interface;
using Protel.Core.Security;
using Protel.DataAccess.Entities;
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
    public class TaskController : ControllerBase
    {
        private readonly ICurrencyTypeBusiness ICurrencyTypeBusiness;
        private readonly ICurrencyInfoBusiness ICurrencyInfoBusiness;
        private readonly IWorkWithCurrencyBusiness IWorkWithCurrencyBusiness;

        public TaskController(ICurrencyTypeBusiness _ICurrencyTypeBusiness, ICurrencyInfoBusiness _ICurrencyInfoBusiness, IWorkWithCurrencyBusiness _IWorkWithCurrencyBusiness)
        {
            ICurrencyTypeBusiness = _ICurrencyTypeBusiness;
            ICurrencyInfoBusiness = _ICurrencyInfoBusiness;
            IWorkWithCurrencyBusiness = _IWorkWithCurrencyBusiness;
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
        
        [HttpPost("TaskWorkWithCurrencies")]
        public async Task<ApiResponse> TaskWorkWithCurrencies()
        {
            return await IWorkWithCurrencyBusiness.AddRangeWithSelectCurrencies();
        }
    }
}
