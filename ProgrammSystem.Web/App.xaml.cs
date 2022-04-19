using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using ProgrammSystem.BLL.Autofac;
using ProgrammSystem.Web.vm;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Services;
using ProgramSystem.Data.Repository.Factories;

namespace ProgrammSystem.Web
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());
            
            var containerBase = builderBase.Build();

            // !!! Для того чтобы обновить бд в соответствии с изменениями, применять только в случае если структура бд изменилась !!!
            //var repositoryContextFactory = containerBase.Resolve<ISqlLiteRepositoryContextFactory>();
            //try
            //{
            //    var context = repositoryContextFactory.Create();

            //    context.Database.Migrate();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Миграции завершились с ошибкой {ex.Message}");
            //    return;
            //}

            //Console.WriteLine("Миграции завершились успешно");

             var viewmodelBase = new AutorizationViewModel(containerBase.Resolve<IUserService>());

            //var viewBase = new MainWindow { DataContext = viewmodelBase };


           

            //var viewmodelBase = new MainWindowProgramViewModel(containerBase.Resolve<IMathService>());
            //var viewBase = new MainWindowProgram { DataContext = viewmodelBase };

            var viewBase = new AutorizationWindow { DataContext = viewmodelBase };

            //var viewBase = new MainWindowProgram { DataContext = viewmodelBase};

            viewBase.Show();
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Ошибка\n" + e.Exception.StackTrace + " " + "Исключение: "
                            + e.Exception.GetType().ToString() + " " + e.Exception.Message);

            e.Handled = true;
        }
    }
}
