using AutoWrapper.Wrappers;
using Protel.Business.Base;
using Protel.Business.Interface;
using Protel.Service.TCMB.Base;
using Protel.Service.TCMB.Interface;
using Protel.Service.TCMB.Model.Response;
using System;
using System.Collections.Generic;
using Xunit;

namespace Protel.Test
{
    public class TCMBServiceTest : IClassFixture<TCMBService>
    {
        private readonly ITCMBService ITCMBService;
        public TCMBServiceTest(ITCMBService _ITCMBService)
        {
            ITCMBService = _ITCMBService;
        }
       
        
        [Fact]
        public async void TCMBServiceMethodTest()
        {
            #region Arrange

            #endregion

            #region Act
            var response = await ITCMBService.GetDailyCurrencyInfos();
            #endregion

            #region Assert
            //Assert.NotEmpty((List<DailyCurrencyInfoResponse>)response.Result);
            //Assert.IsType<List<DailyCurrencyInfoResponse>>(response.Result);
            Assert.IsAssignableFrom<ApiResponse>(response);
            #endregion
        }
    }
}
