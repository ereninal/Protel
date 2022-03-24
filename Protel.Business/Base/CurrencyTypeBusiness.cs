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
    public class CurrencyTypeBusiness : ICurrencyTypeBusiness
    {
        private readonly ICurrencyTypeRepository ICurrencyTypeRepository;
        private readonly ITCMBService ITCMBService;

        public CurrencyTypeBusiness(ICurrencyTypeRepository _ICurrencyTypeRepository, ITCMBService _ITCMBService)
        {
            ICurrencyTypeRepository = _ICurrencyTypeRepository;
            ITCMBService = _ITCMBService;
        }

        public Task<ApiResponse> Add()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> AddRange()
        {
            var response = await ITCMBService.GetDailyCurrencyInfos();
            var datas = new List<CurrencyType>();
            if (!response.IsError.Value)
            {
                foreach (var item in (List<DailyCurrencyInfoResponse>)response.Result)
                {
                    datas.Add(new CurrencyType
                    {
                        CurrencyCode = item.Code,
                        EngName = item.CurrencyName,
                        TrName = item.Isim,
                    });
                }
                ICurrencyTypeRepository.AddRange(datas);

            }
            response.Result = ICurrencyTypeRepository.GetList(m => m.IsDeleted == false);
            return response;
        }
    }
}
