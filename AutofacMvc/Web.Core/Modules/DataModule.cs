using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.DbEntities;
using Web.Core.Repositories;
using Web.Interfaces;
using Web.Interfaces.Interfaces;

namespace Web.Core.Modules
{
    public class DataModule : Module
    {
        private readonly string connStr;
        public DataModule(string connString)
        {
            this.connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(con => new WebDbContext(connStr)).As<IDbContext>().InstancePerRequest();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerDependency();
            builder.RegisterType<BookCategoriesService>().As<IBookCategoriesService>().InstancePerDependency();
            base.Load(builder);
        }
    }
}
