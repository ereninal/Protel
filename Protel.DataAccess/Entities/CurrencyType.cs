using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Entities
{
    public class CurrencyType : BaseEntitiy, IEntity
    {
        public string EngName { get; set; }
        public string TrName { get; set; }
        public string CurrencyCode { get; set; }
        public virtual ICollection<CurrencyInfo> CurrencyInfos { get; set; }
        public virtual ICollection<CurrencyChangeInfo> CurrencyChangeInfos { get; set; }
    }
    public class CurrencyTypeEntityConfiguration : IEntityTypeConfiguration<CurrencyType>
    {
        public void Configure(EntityTypeBuilder<CurrencyType> builder)
        {
            builder.HasMany(m => m.CurrencyInfos)
             .WithOne(e => e.CurrencyType)
             .HasForeignKey(e => e.CurrencyTypeId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.CurrencyChangeInfos)
             .WithOne(e => e.CurrencyType)
             .HasForeignKey(e => e.CurrencyTypeId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
