using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.Interfaces;

namespace ProgrammSystem.Web.vm
{
    public class MainWindowProgramViewModel: ViewModelBase
    {
        private readonly IUserService _userService;

        #region Fields
        private string? lenght; //длина
        private string? weight;//ширина
        private string? height; //глубина

        private string? typeOfMaterial;
        private string? ro;
        private string? c;
        private string? temp0;

        private string? speedU;
        private string? tempU;

        private string? step;

        private string? m0;
        private string? b;
        private string? tempR;
        private string? n;
        private string? koefU;

        #endregion

        #region Properties

        public string? Lenght
        {
            get
            {
                return lenght;
            }
            set
            {
                lenght = value;
                OnPropertyChanged();
            }
        }
        public string? Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }
        public string? Height
        {
            get 
            { 
                return height; 
            }
            set
            {
                height = value;
                OnPropertyChanged();
            }

        }
        public string? TypeOfMaterial
        {
            get
            {
                return typeOfMaterial;
            }
            set
            {
                typeOfMaterial = value;
                OnPropertyChanged();
            }
        }
        public string? Ro
        {
            get
            { 
                return ro;
            }
            set
            {
                ro = value;
                OnPropertyChanged();
            }
        }
        public string? C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                OnPropertyChanged();
            }
        }
        public string? Temp0
        {
            get
            {
                return temp0;
            }
            set
            {
                temp0 = value;
                OnPropertyChanged();
            }
        }
        public string? SpeedU
        {
            get
            {
                return speedU;
            }
            set
            {
                speedU = value;
                OnPropertyChanged();
            }
        }
        public string? TempU
        {
            get
            {
                return tempU;
            }
            set
            {
                tempU = value;
                OnPropertyChanged();
            }
        }
        public string? Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                OnPropertyChanged();
            }
        }
        public string? M0
        {
            get
            {
                return m0;
            }
            set
            {
                m0 = value;
                OnPropertyChanged();
            }
        }
        public string? B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                OnPropertyChanged();
            }
        }
        public string? TempR
        {
            get
            {
                return tempR;
            }
            set
            {
                tempR = value;
                OnPropertyChanged();
            }
        }
        public string? N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
                OnPropertyChanged();
            }
        }
        public string? KoefU
        {
            get
            {
                return koefU;
            }
            set
            {
                koefU = value;
                OnPropertyChanged();
            }
        }
        
        #endregion


        #region Commands
        public AsyncCommand MainWindowProgramCommand { get; set; }
        #endregion

        public MainWindowProgramViewModel(IUserService userService)
        {
            //Login = "researcher/admin";
            //Password = "researcher";

            _userService = userService;
           // AuthorizationCommand = new AsyncCommand(AuthorizationAsync, CanAuthorization);
        }

        #region Methods
        //private async Task AuthorizationAsync()
        //{
        //    var user = _userService.GetAccountByLoginPassword(Login ?? "", new NetworkCredential("", Password).Password);
        //    var users = _userService.GetAllUsers();
        //    string uString = "";
        //    foreach (var u in users)
        //    {
        //        uString += u.Id + " Логин: " + u.Login + " Роль: " + u.Role + "\n";
        //    }
        //    MessageBox.Show(uString);
        //    if (user == null)
        //    {
        //        MessageBox.Show("Неверный логин или пароль");
        //    }
        //    else if (user.Role == "admin")
        //    {
        //        MessageBox.Show("Вход под админом\n Пользователь " + user.Login);
        //    }
        //    else if (user.Role == "researcher")
        //    {
        //        MessageBox.Show("Вход под исследователем\n Пользователь " + user.Login);
        //    }
        //}

        //private bool CanAuthorization() => !string.IsNullOrEmpty(Login) && Password != null;

        #endregion


    }
}
