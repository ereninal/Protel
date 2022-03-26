using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.DTO.Response
{
    public class DtoCurrencyChangeInfo
    {
        public string Currency { get; set; }
        public DateTime LastUpdated { get; set; }
        public decimal CurrenctRate { get; set; }
        public string Rate { get; set; }
    }
}
