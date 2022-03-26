using Protel.DataAccess.Context;
using Protel.DataAccess.DTO.Response;
using Protel.DataAccess.Entities;
using Protel.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Repository.Base
{
    public class CurrencyInfoRepository : BaseRepository<CurrencyInfo, ProtelContext>, ICurrencyInfoRepository
    {
        public List<DtoCurrencyChangeInfo> GetDtoCurrencyChangeInfo(string currencyType)
        {
            var sDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var eDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            var dataByDaily = this.GetList(m => m.CreateDate >= sDate && m.CreateDate <= eDate);
            using (var context = new ProtelContext())
            {
                var data = from ci in context.CurrencyChangeInfos
                           join cti in context.Currencies on ci.CurrencyTypeId equals cti.Id
                           where cti.CurrencyCode == currencyType
                           select new DtoCurrencyChangeInfo
                           {
                               Currency = cti.CurrencyCode + "-TRY",
                               CurrenctRate = ci.CurrentRate,
                               LastUpdated = ci.UpdateDate.HasValue ? ci.UpdateDate.Value : ci.CreateDate.Value,
                               Rate = ci.Change + "%" 
                           };
                return data.OrderBy(m => m.CurrenctRate).ToList();
            }
        }

        public List<DtoCurrencyInfoResponse> GetDtoCurrencyInfo()
        {
            var sDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var eDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            using (var context = new ProtelContext())
            {
                var data = from ci in context.CurrencyInfo
                           join cti in context.Currencies on ci.CurrencyTypeId equals cti.Id
                           where ci.CreateDate >= sDate && ci.CreateDate <= eDate  && ci.IsDeleted == false
                           select new DtoCurrencyInfoResponse 
                           {
                               Currency =cti.CurrencyCode+"-TRY",
                               CurrenctRate =ci.ForexBuying,
                               LastUpdated = ci.UpdateDate.HasValue ? ci.UpdateDate.Value : ci.CreateDate.Value
                           };
                return data.OrderBy(m=>m.CurrenctRate).ToList();
            }
        }
    }
}
