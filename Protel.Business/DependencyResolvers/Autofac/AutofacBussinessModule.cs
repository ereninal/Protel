using Autofac;
using Protel.Business.Base;
using Protel.Business.Interface;
using Protel.DataAccess.Repository.Base;
using Protel.DataAccess.Repository.Interface;
using Protel.Service.TCMB.Base;
using Protel.Service.TCMB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Protel.Business.DependencyResolvers.Autofac
{
    public class AutofacBussinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new HttpClient()).As<HttpClient>();

            builder.RegisterType<TCMBService>().As<ITCMBService>().InstancePerLifetimeScope();

            builder.RegisterType<CurrencyTypeBusiness>().As<ICurrencyTypeBusiness>().SingleInstance();
            builder.RegisterType<CurrencyTypeRepository>().As<ICurrencyTypeRepository>().SingleInstance();

            builder.RegisterType<CurrencyInfoRepository>().As<ICurrencyInfoRepository>().SingleInstance();
            builder.RegisterType<CurrencyInfoBusiness>().As<ICurrencyInfoBusiness>().SingleInstance();

            builder.RegisterType<WorkWithCurrencyRepository>().As<IWorkWithCurrencyRepository>().SingleInstance();
            builder.RegisterType<WorkWithCurrencyBusiness>().As<IWorkWithCurrencyBusiness>().SingleInstance();

            builder.RegisterType<CurrencyChangeInfoRepository>().As<ICurrencyChangeInfoRepository>().SingleInstance();

        }
    }
}
