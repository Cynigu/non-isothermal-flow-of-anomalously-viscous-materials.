using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Autofac;
using ProgrammSystem.BLL.Autofac;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.Interfaces;

namespace ProgrammSystem.Web.vm
{
    public class AutorizationViewModel: ViewModelBase
    {
        private readonly IUserService _userService;

        #region Fields
        private string? login;
        private SecureString? password;
        #endregion

        #region Properties

        public string? Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public SecureString? Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }


        #endregion


        #region Commands 
        public RelayCommand AuthorizationCommand { get; set; }

        #endregion

        public AutorizationViewModel(IUserService userService)
        {
            Login = "researcher/admin";
            //Password = "researcher";
            _userService = userService;

            AuthorizationCommand = new RelayCommand(obj => Authorization(), obj => CanAuthorization());
        }

        #region Methods
        private void Authorization() //запускается при клике на кнопку
        {
            var user = _userService.GetAccountByLoginPassword(Login ?? "", new NetworkCredential("", Password).Password);
            var users = _userService.GetAllUsers();
            string uString = "";
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();
            foreach (var u in users)
            {
                uString += u.Id + " Логин: " + u.Login + " Роль: " + u.Role +"\n";
            }
            MessageBox.Show(uString);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else if (user.Role == "admin")
            {
                MessageBox.Show("Вход под админом\n Пользователь " + user.Login);
                var viewmodelBase = new WindowEditViewModel();
                var viewBase = new WindowEdit { DataContext = viewmodelBase };

                viewBase.Show();
            }
            else if (user.Role == "researcher")
            {
                MessageBox.Show("Вход под исследователем\n Пользователь " + user.Login);
                
                var viewmodelBase = new MainWindowProgramViewModel(containerBase.Resolve<IMathService>());
                var viewBase = new MainWindowProgram { DataContext = viewmodelBase };

                viewBase.Show();

            }
        }

        private bool CanAuthorization() => !string.IsNullOrEmpty(Login) && Password != null; //проверка

        #endregion



    }
}
