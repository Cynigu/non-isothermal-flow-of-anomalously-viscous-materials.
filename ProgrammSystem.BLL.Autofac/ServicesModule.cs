using Autofac;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Services;
using ProgramSystem.Data.Repository.Factories;

namespace ProgrammSystem.BLL.Autofac
{
    public class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserBaseService(c.Resolve<ISqlLiteRepositoryContextFactory>()))
                .As<IUserBaseService>();
        }
    }
}