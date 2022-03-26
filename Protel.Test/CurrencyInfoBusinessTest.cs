using AutoWrapper.Wrappers;
using Protel.Business.Base;
using Protel.Business.Interface;
using Protel.DataAccess.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Protel.Test
{
    public class CurrencyInfoBusinessTest : IClassFixture<CurrencyInfoBusiness>
    {
        private readonly ICurrencyInfoBusiness ICurrencyInfoBusiness;
        public CurrencyInfoBusinessTest(ICurrencyInfoBusiness _ICurrencyInfoBusiness)
        {
            ICurrencyInfoBusiness = _ICurrencyInfoBusiness;
        }
        [Theory]
        [InlineData("USD")]
        [InlineData("EUR")]
        public async  void GetChangeByCurrencyMethodTest(string currency)
        {
            #region Arrange

            #endregion

            #region Act
            var response = await ICurrencyInfoBusiness.GetChangeByCurrency(currency);
            #endregion

            #region Assert
            Assert.NotEmpty((List<DtoCurrencyChangeInfo>)response.Result);
            Assert.IsType<List<DtoCurrencyChangeInfo>>(response.Result);
            Assert.IsAssignableFrom<ApiResponse>(response);
            #endregion
        }
    }
}
