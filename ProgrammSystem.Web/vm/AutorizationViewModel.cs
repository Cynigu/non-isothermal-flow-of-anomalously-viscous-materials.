using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.Interfaces;

namespace ProgrammSystem.Web.vm
{
    public class AutorizationViewModel: ViewModelBase
    {
        private readonly IUserBaseService _userBaseService;

        private string? login;
        private SecureString? password;

        
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

        public AsyncCommand AuthorizationCommand;

        public AutorizationViewModel(IUserBaseService userBaseService)
        {
            Login = "researcher/admin";
            //Password = "researcher";
            _userBaseService = userBaseService;
            AuthorizationCommand = new AsyncCommand(AuthorizationAsync, null);
        }

        private async Task AuthorizationAsync()
        {
            var user = _userBaseService.GetAccountByLoginPassword(Login, new NetworkCredential("", Password).Password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else if (user.Role == "admin")
            {
                MessageBox.Show("Вход под админом\n Пользователь " + user.Login);
            }
            else if (user.Role == "user")
            {
                MessageBox.Show("Вход под пользователем\n Пользователь " + user.Login);
            }
        }

        private bool CanAuthorization() => !string.IsNullOrEmpty(Login) && Password != null;
    }
}
