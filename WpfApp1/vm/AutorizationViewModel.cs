using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Annotations;
using WpfApp1.Commands;

namespace WpfApp1.vm
{
    public class AutorizationViewModel: ViewModelBase
    {
        private readonly IUserBaseService _userBaseService;

        [CanBeNull] private string login;
        [CanBeNull] private string password;

        [CanBeNull]
        public string Login
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

        [CanBeNull]
        public string Password
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
            Login = "user";
            Password = "user";
            _userBaseService = userBaseService;
            AuthorizationCommand = new AsyncCommand(AuthorizationAsync, null);
        }

        private async Task AuthorizationAsync()
        {

        }

        private bool CanAuthorization() => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
    }
}
