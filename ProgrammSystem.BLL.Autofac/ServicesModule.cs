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
            builder.Register(c => new UserService(c.Resolve<ISqlLiteRepositoryContextFactory>())).As<IUserService>();
            builder.Register(c => new UnitOfMeasService(c.Resolve<ISqlLiteRepositoryContextFactory>())).As<IUnitOfMeasService>();
            builder.Register(c => new MaterialService(c.Resolve<ISqlLiteRepositoryContextFactory>())).As<IMaterialService>();
            builder.Register(c => new MathService()).As<IMathService>();
        }
    }
}