using Protel.DataAccess.Context;
using Protel.DataAccess.Entities;
using Protel.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Repository.Base
{
    public class CurrencyInfoRepository : BaseRepository<CurrencyType, ProtelContext>, ICurrencyInfoRepository
    {
    }
}
