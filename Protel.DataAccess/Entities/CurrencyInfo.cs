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
        public int CurrencyTypeId { get; set; }
        public decimal CurrentRate { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }

    }
    public class CurrencyInfoEntityConfiguration : IEntityTypeConfiguration<CurrencyInfo>
    {
        public void Configure(EntityTypeBuilder<CurrencyInfo> builder)
        {
        }
    }
}
