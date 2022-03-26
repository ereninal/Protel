using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using Protel.Business.Base;
using Protel.Business.Interface;
using Protel.Service.TCMB.Base;
using Protel.Service.TCMB.Interface;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Protel.Test.Startup))]

namespace Protel.Test
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient<ITCMBService, TCMBService>();
            services.AddSingleton<ICurrencyInfoBusiness, CurrencyInfoBusiness>();
        }
    }
}
