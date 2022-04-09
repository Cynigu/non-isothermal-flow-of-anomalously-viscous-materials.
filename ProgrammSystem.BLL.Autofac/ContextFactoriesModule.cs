using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Data.Repository.Factories;

namespace ProgrammSystem.BLL.Autofac
{
    public class ContextFactoriesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SqlLiteRepositoryContextFactoryAsync("Data Source = rpkDB.db"))
                .As<ISqlLiteRepositoryContextFactory>();
        }
    }
}
