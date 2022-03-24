using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Service.TCMB.Model.Response
{
    public class DailyCurrencyInfoResponse
    {
        public int Unit { get; set; }
        public string Isim { get; set; }
        public string CurrencyName { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
        public decimal CrossRateUSD { get; set; }
        public decimal CrossRateOther { get; set; }
        public string Code { get; set; }
    }
}
