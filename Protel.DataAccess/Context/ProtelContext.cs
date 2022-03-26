using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Protel.Core.Security;
using Protel.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protel.DataAccess.Context
{
    public class ProtelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["connectionString"].Decrypt());
            optionsBuilder.UseNpgsql(@"Server=ec2-99-80-170-190.eu-west-1.compute.amazonaws.com;Port=5432;Database=d345u6tv5p7flv;User Id=xqcpgzudjxwqbd;Password=799220303b950a25b68ac23a3047233ae9e80e42354baae49fca29a2dade53e5;Integrated Security=false;Pooling=true;sslmode=Require;Trust Server Certificate=true;");
        }
        public DbSet<CurrencyType> Currencies { get; set; }
        public DbSet<CurrencyInfo> CurrencyInfo { get; set; }
        public DbSet<CurrencyChangeInfo> CurrencyChangeInfos { get; set; }
        public DbSet<WorkWithCurrency> WorkWithCurrencies { get; set; }
    }
}
