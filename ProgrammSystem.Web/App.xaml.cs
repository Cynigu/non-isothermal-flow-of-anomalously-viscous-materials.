using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ProgrammSystem.Web.vm;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Services;

namespace ProgrammSystem.Web
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builderBase = new ContainerBuilder();
            builderBase.RegisterType<IUserBaseService>().As<UserBaseService>();
            //builderBase.RegisterType<ViewModelBase>().AsSelf();
            var containerBase = builderBase.Build();

            var viewmodelBase = new AutorizationViewModel(containerBase.Resolve<IUserBaseService>());
            //var viewBase = new MainWindow { DataContext = viewmodelBase };

            var viewBase = new AutorizationWindow { DataContext = viewmodelBase };
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
