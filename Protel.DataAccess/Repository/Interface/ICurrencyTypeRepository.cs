using Protel.DataAccess.DTO.Response;
using Protel.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Repository.Interface
{
    public interface ICurrencyTypeRepository : IRepository<CurrencyType>
    {
        List<DtoCurrencyInfoResponse> GetDtoCurrencyInfo();
    }
}
