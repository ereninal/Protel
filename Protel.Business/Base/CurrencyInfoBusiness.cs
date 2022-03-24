using AutoWrapper.Wrappers;
using Protel.Business.Interface;
using Protel.DataAccess.Entities;
using Protel.DataAccess.Repository.Interface;
using Protel.Service.TCMB.Interface;
using Protel.Service.TCMB.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Business.Base
{
    public class CurrencyInfoBusiness : ICurrencyInfoBusiness
    {
        private readonly ICurrencyInfoRepository ICurrencyInfoRepository;
        private readonly ICurrencyTypeRepository ICurrencyTypeRepository;
        private readonly ITCMBService ITCMBService;
        public CurrencyInfoBusiness(ICurrencyInfoRepository _ICurrencyInfoRepository, ITCMBService _ITCMBService, ICurrencyTypeRepository _ICurrencyTypeRepository)
        {
            ICurrencyInfoRepository = _ICurrencyInfoRepository;
            ICurrencyTypeRepository = _ICurrencyTypeRepository;
            ITCMBService = _ITCMBService;
        }

        public async Task<ApiResponse> AddRangeByDaily()
        {
            var response = await ITCMBService.GetDailyCurrencyInfos();
            var datas = new List<CurrencyInfo>();
            var currencyType = ICurrencyTypeRepository.GetList(m => m.IsDeleted == false).Select(m => new { m.Id,m.CurrencyCode}).ToList();
            if (!response.IsError.Value)
            {
                foreach (var item in (List<DailyCurrencyInfoResponse>)response.Result)
                {
                    datas.Add(new CurrencyInfo
                    {
                        CurrencyTypeId = currencyType.Where(m => m.CurrencyCode == item.Code.Trim()).FirstOrDefault().Id,
                        ForexSelling = item.ForexSelling,
                        ForexBuying = item.ForexBuying,
                        BanknoteBuying = item.BanknoteBuying,
                        BanknoteSelling = item.BanknoteSelling,
                    });
                }
                ICurrencyInfoRepository.AddRange(datas);
            }
            response.Result = ICurrencyInfoRepository.GetList(m => m.IsDeleted == false);
            return response;
        }
    }
}
