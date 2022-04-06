using System.Threading.Tasks;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.Interfaces;

namespace ProgrammSystem.Web.vm
{
    public class AutorizationViewModel: ViewModelBase
    {
        private readonly IUserBaseService _userBaseService;

        private string? login;
        private string? password;

        
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

       
        public string? Password
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
