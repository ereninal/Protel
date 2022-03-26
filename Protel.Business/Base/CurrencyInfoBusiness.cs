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
    public class CurrencyInfoBusiness : ICurrencyInfoBusiness
    {
        private readonly ICurrencyInfoRepository ICurrencyInfoRepository;
        private readonly ICurrencyChangeInfoRepository ICurrencyChangeInfoRepository;
        private readonly ICurrencyTypeRepository ICurrencyTypeRepository;
        private readonly IWorkWithCurrencyRepository IWorkWithCurrencyRepository;
        private readonly ITCMBService ITCMBService;
        public CurrencyInfoBusiness(ICurrencyInfoRepository _ICurrencyInfoRepository, ITCMBService _ITCMBService, ICurrencyTypeRepository _ICurrencyTypeRepository, IWorkWithCurrencyRepository _IWorkWithCurrencyRepository, ICurrencyChangeInfoRepository _ICurrencyChangeInfoRepository)
        {
            ICurrencyInfoRepository = _ICurrencyInfoRepository;
            ICurrencyTypeRepository = _ICurrencyTypeRepository;
            IWorkWithCurrencyRepository = _IWorkWithCurrencyRepository;
            ICurrencyChangeInfoRepository = _ICurrencyChangeInfoRepository;
            ITCMBService = _ITCMBService;
        }

        public async Task<ApiResponse> GetChangeByCurrency(string code)
        {
            //Anlık çekilen data ile bi önceki data kıyaslanarak bir kayıt atılıyor
            ApiResponse apiResponse = new ApiResponse("", "", (int)HttpStatusCode.OK);
            apiResponse.IsError = false;
            try
            {
                var response = await ITCMBService.GetDailyCurrencyInfos();
                var datas = new List<CurrencyChangeInfo>();
                var updateCurrency = (List<DailyCurrencyInfoResponse>)response.Result;
                var sDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var eDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                var currencyType = ICurrencyTypeRepository.GetList(m => m.IsDeleted == false).Select(m => new { m.Id, m.CurrencyCode }).ToList();
                var workInCurrencies = IWorkWithCurrencyRepository.GetList();
                var oldCurrencies = ICurrencyInfoRepository.GetList().OrderByDescending(m=>m.CreateDate).ToList();

                if (!response.IsError.Value)
                {
                    foreach (var item in updateCurrency)
                    {
                        if (workInCurrencies.Any(m => m.CurrencyCode == item.Code))
                        {
                            var oldValue = oldCurrencies.Where(m => m.CurrencyTypeId == currencyType.Where(m => m.CurrencyCode == item.Code.Trim()).FirstOrDefault().Id).FirstOrDefault().ForexBuying;
                            var diff = item.ForexBuying - oldValue;
                            datas.Add(new CurrencyChangeInfo
                            {
                                CurrencyTypeId = currencyType.Where(m => m.CurrencyCode == item.Code.Trim()).FirstOrDefault().Id,
                                UpdateDate = DateTime.Now.Date,
                                CurrentRate = item.ForexBuying,
                                Change = diff > 0 ?"-"+((diff*100) / oldValue).ToString("0.0") : "+" + (((-1)*diff * 100) / oldValue).ToString("0.0")
                            });
                        }

                    }
                    //O güne ait kayıt var ise silip güncel olanları ekliyoruz, yok ise direkt ekleme yapıyoruz
                    var oldCurrencyChanges = ICurrencyChangeInfoRepository.GetList(m => m.CreateDate >= sDate && m.CreateDate <= eDate);
                    if (oldCurrencies.Count > 0)
                        ICurrencyChangeInfoRepository.DeleteRange(oldCurrencyChanges);
                    ICurrencyChangeInfoRepository.AddRange(datas);
                }

                apiResponse.Result = ICurrencyInfoRepository.GetDtoCurrencyChangeInfo(code.ToUpper());

            }
            catch (Exception ex)
            {

                apiResponse.IsError = true;
                apiResponse.Message = "Hata : " + ex.Message;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> GetCurrencyInfos()
        {
            var response = await ITCMBService.GetDailyCurrencyInfos();
            var datas = new List<CurrencyInfo>();
            var responseData = (List<DailyCurrencyInfoResponse>)response.Result;
            var sDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var eDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            var currencyType = ICurrencyTypeRepository.GetList(m => m.IsDeleted == false).Select(m => new { m.Id, m.CurrencyCode }).ToList();
            var workInCurrencies = IWorkWithCurrencyRepository.GetList();
            if (!response.IsError.Value)
            {
                foreach (var item in responseData)
                {
                    if (workInCurrencies.Any(m => m.CurrencyCode == item.Code))
                    {
                        datas.Add(new CurrencyInfo
                        {
                            CurrencyTypeId = currencyType.Where(m => m.CurrencyCode == item.Code.Trim()).FirstOrDefault().Id,
                            ForexSelling = item.ForexSelling,
                            ForexBuying = item.ForexBuying,
                            BanknoteBuying = item.BanknoteBuying,
                            BanknoteSelling = item.BanknoteSelling,
                            UpdateDate = DateTime.Now.Date
                        });
                    }

                }


                var dailyCurrencies = ICurrencyInfoRepository.GetList(m => m.CreateDate >= sDate && m.CreateDate <= eDate);
                if (dailyCurrencies.Count > 0)
                    ICurrencyInfoRepository.DeleteRange(dailyCurrencies);
                ICurrencyInfoRepository.AddRange(datas);
            }
            response.Result = ICurrencyInfoRepository.GetDtoCurrencyInfo();
            return response;
        }

        public async Task<ApiResponse> GetList()
        {
            ApiResponse apiResponse = new ApiResponse("", "", (int)HttpStatusCode.OK);
            apiResponse.IsError = false;
            try
            {
                apiResponse.Result = ICurrencyInfoRepository.GetDtoCurrencyInfo();
                apiResponse.Message = "Güncel para birimleri çekildi.";
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
