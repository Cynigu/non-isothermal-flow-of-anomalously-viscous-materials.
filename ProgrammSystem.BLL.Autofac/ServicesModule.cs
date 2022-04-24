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
            builder.Register(c => new UserService(c.Resolve<ISqlLiteRepositoryContextFactory>()))
                .As<IUserService>();
            builder.Register(c => new UnitOfMeasService(c.Resolve<ISqlLiteRepositoryContextFactory>()))
                .As<IUnitOfMeasService>();
            builder.Register(c => new MaterialService(c.Resolve<ISqlLiteRepositoryContextFactory>()))
                .As<IMaterialService>();
            builder.Register(c => new ParameterService(c.Resolve<ISqlLiteRepositoryContextFactory>()))
                .As<IParameterService>();
            builder.Register(c => new EmpiricalParameterValueService(
                c.Resolve<ISqlLiteRepositoryContextFactory>(), c.Resolve<IParameterService>(), c.Resolve<IMaterialService>()))
                .As<IEmpiricalParameterValuesService>();
            builder.Register(c => new MaterialParameterValuesService(
                    c.Resolve<ISqlLiteRepositoryContextFactory>(), c.Resolve<IParameterService>(), c.Resolve<IMaterialService>()))
                .As<IMaterialParameterValuesService>();

            builder.Register(c => new MathService()).As<IMathService>();
        }
    }
}