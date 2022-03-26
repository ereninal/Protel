using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Entities
{
    public class CurrencyChangeInfo : BaseEntitiy, IEntity
    {
        public Int64 CurrencyTypeId { get; set; }
        public decimal CurrentRate { get; set; }
        public string Change { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
        public class CurrencyInfoEntityConfiguration : IEntityTypeConfiguration<CurrencyChangeInfo>
        {
            public void Configure(EntityTypeBuilder<CurrencyChangeInfo> builder)
            {
            }
        }
    }
}
