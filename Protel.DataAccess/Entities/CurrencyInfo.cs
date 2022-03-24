using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Entities
{
    public class CurrencyInfo : BaseEntitiy,IEntity
    {
        public Int64 CurrencyTypeId { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }

    }
    public class CurrencyInfoEntityConfiguration : IEntityTypeConfiguration<CurrencyInfo>
    {
        public void Configure(EntityTypeBuilder<CurrencyInfo> builder)
        {
        }
    }
}
