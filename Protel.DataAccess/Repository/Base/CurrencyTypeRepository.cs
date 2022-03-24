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
    public class CurrencyTypeRepository : BaseRepository<CurrencyType, ProtelContext>, ICurrencyTypeRepository
    {
        public List<DtoCurrencyInfoResponse> GetDtoCurrencyInfo()
        {
            using (var context = new ProtelContext())
            {

            }
            return new List<DtoCurrencyInfoResponse>();
        }
    }
}
