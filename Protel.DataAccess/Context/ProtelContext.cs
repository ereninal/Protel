using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Protel.Core.Security;
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
            optionsBuilder.UseNpgsql(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["connectionString"].Decrypt());
        }
    }
}
