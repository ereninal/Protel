using AutoWrapper.Wrappers;
using Protel.Business.Interface;
using Protel.DataAccess.Entities;
using Protel.DataAccess.Repository.Interface;
using Protel.Service.TCMB.Interface;
using Protel.Service.TCMB.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Business.Base
{
    public class WorkWithCurrencyBusiness : IWorkWithCurrencyBusiness
    {
        private readonly IWorkWithCurrencyRepository IWorkWithCurrencyRepository;
        private readonly ITCMBService ITCMBService;

        public WorkWithCurrencyBusiness(IWorkWithCurrencyRepository _IWorkWithCurrencyRepository, ITCMBService _ITCMBService)
        {
            IWorkWithCurrencyRepository = _IWorkWithCurrencyRepository;
            ITCMBService = _ITCMBService;
        }
        public ApiResponse Add(WorkWithCurrency currency)
        {
            ApiResponse apiResponse = new ApiResponse("", "", (int)HttpStatusCode.OK);
            apiResponse.IsError = false;
            try
            {
                IWorkWithCurrencyRepository.Add(currency);

                apiResponse.Message = "Para birimi eklendi";
            }
            catch (Exception ex)
            {

                apiResponse.IsError = true;
                apiResponse.Message = "Hata : " + ex.Message;
            }
            return apiResponse;
        }

        public ApiResponse AddRange(List<WorkWithCurrency> currencies)
        {
            ApiResponse apiResponse = new ApiResponse("", "", (int)HttpStatusCode.OK);
            apiResponse.IsError = false;
            try
            {
                IWorkWithCurrencyRepository.AddRange(currencies);

                apiResponse.Message = "Para birimi eklendi";
            }
            catch (Exception ex)
            {

                apiResponse.IsError = true;
                apiResponse.Message = "Hata : " + ex.Message;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> AddRangeWithSelectCurrencies()
        {
            ApiResponse apiResponse = new ApiResponse("", "", (int)HttpStatusCode.OK);
            apiResponse.IsError = false;
            var selectCurrencies = new List<WorkWithCurrency>();
            try
            {
                var response = await ITCMBService.GetDailyCurrencyInfos();
                if (!response.IsError.Value)
                {
                    foreach (var item in (List<DailyCurrencyInfoResponse>)response.Result)
                    {
                        if(item.Code == "USD" || item.Code == "EUR" || item.Code == "GBP" || item.Code == "CHF" || item.Code == "KWD" || item.Code == "SAR" || item.Code == "RUB")
                        {
                            selectCurrencies.Add(new WorkWithCurrency
                            {
                                TrName = item.Isim,
                                EngName = item.CurrencyName,
                                CurrencyCode = item.Code
                            });
                        }
                        
                    }
                    IWorkWithCurrencyRepository.AddRange(selectCurrencies);
                }
                apiResponse.Message = "Seçilen para birimleri eklendi.";
            }
            catch (Exception ex)
            {

                apiResponse.IsError = true;
                apiResponse.Message = "Hata : " + ex.Message;
            }
            return apiResponse;
        }
    }
}
