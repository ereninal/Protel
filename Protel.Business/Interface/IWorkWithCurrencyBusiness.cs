using AutoWrapper.Wrappers;
using Protel.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Business.Interface
{
    public interface IWorkWithCurrencyBusiness
    {
        ApiResponse Add(WorkWithCurrency currency);
        ApiResponse AddRange(List<WorkWithCurrency> currencies);
        Task<ApiResponse> AddRangeWithSelectCurrencies();
    }
}
