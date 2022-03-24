using AutoWrapper.Wrappers;
using Protel.Service.TCMB.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Service.TCMB.Interface
{
    public interface ITCMBService
    {
        Task<ApiResponse> GetDailyCurrencyInfos();
    }
}
