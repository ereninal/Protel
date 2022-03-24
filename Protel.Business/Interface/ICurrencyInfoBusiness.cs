using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Business.Interface
{
    public interface ICurrencyInfoBusiness
    {
        Task<ApiResponse> AddRangeByDaily();
    }
}
