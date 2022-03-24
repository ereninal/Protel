using AutoWrapper.Wrappers;
using Grpc.Core;
using Protel.Service.TCMB.Interface;
using Protel.Service.TCMB.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Protel.Service.TCMB.Base
{
    public class TCMBService : ITCMBService
    {
        private readonly HttpClient HttpClient;
        public TCMBService(HttpClient _HttpClient)
        {
            HttpClient = _HttpClient;
        }
        public async Task<ApiResponse> GetDailyCurrencyInfos()
        {
            ApiResponse apiResponse = new ApiResponse("", "", (int)HttpStatusCode.OK);
            apiResponse.IsError = false;
            try
            {
                var response = await HttpClient.GetAsync("https://www.tcmb.gov.tr/kurlar/today.xml");
                string apiResponseService = await response.Content.ReadAsStringAsync();
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(apiResponseService);
                List<DailyCurrencyInfoResponse> responseData = new List<DailyCurrencyInfoResponse>();
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string kurlar = item.ChildNodes[2].InnerText;
                    responseData.Add(new DailyCurrencyInfoResponse
                    {
                        Unit = int.Parse(item.ChildNodes[0].InnerText),
                        Isim = item.ChildNodes[1].InnerText.Trim(),
                        CurrencyName = item.ChildNodes[2].InnerText.Trim(),
                        BanknoteBuying = !string.IsNullOrWhiteSpace(item.ChildNodes[5].InnerText) ? Convert.ToDecimal(item.ChildNodes[5].InnerText) : 0,
                        BanknoteSelling = !string.IsNullOrWhiteSpace(item.ChildNodes[6].InnerText) ? Convert.ToDecimal(item.ChildNodes[6].InnerText) : 0,
                        CrossRateOther = !string.IsNullOrWhiteSpace(item.ChildNodes[7].InnerText) ? Convert.ToDecimal(item.ChildNodes[7].InnerText) : 0,
                        CrossRateUSD = !string.IsNullOrWhiteSpace(item.ChildNodes[8].InnerText) ? Convert.ToDecimal(item.ChildNodes[8].InnerText) : 0,
                        ForexBuying = !string.IsNullOrWhiteSpace(item.ChildNodes[3].InnerText) ? Convert.ToDecimal(item.ChildNodes[3].InnerText) : 0,
                        ForexSelling = !string.IsNullOrWhiteSpace(item.ChildNodes[4].InnerText) ? Convert.ToDecimal(item.ChildNodes[4].InnerText) : 0,
                        Code = item.Attributes[1].InnerText

                    });
                }
                apiResponse.Result = responseData;
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
