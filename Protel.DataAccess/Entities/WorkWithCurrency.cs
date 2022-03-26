using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Entities
{
    public class WorkWithCurrency : BaseEntitiy, IEntity
    {
        public string EngName { get; set; }
        public string TrName { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class WorkWithCurrencyEntityConfiguration : IEntityTypeConfiguration<WorkWithCurrency>
    {
        public void Configure(EntityTypeBuilder<WorkWithCurrency> builder)
        {
            
        }
    }
}
