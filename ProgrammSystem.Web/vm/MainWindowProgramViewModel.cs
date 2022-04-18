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
        private readonly IMathService _mathService;
        private Results _res;
        #region Fields
        private double lenght; //длина
        private double weight;//ширина
        private double height; //глубина

        private double typeOfMaterial;
        private double ro;
        private double c;
        private double temp0;

        private double speedU;
        private double tempU;

        private double step;

        private double m0;
        private double b;
        private double tempR;
        private double n;
        private double koefU;

        #endregion

        #region Properties

        public double Lenght
        {
            get => lenght;
            set
            {
                lenght = value;
                OnPropertyChanged();
            }
        }
        public double Weight
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
        public double Height
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
        public double TypeOfMaterial
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
        public double Ro
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
        public double C
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
        public double Temp0
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
        public double SpeedU
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
        public double TempU
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
        public double Step
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
        public double M0
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
        public double B
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
        public double TempR
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
        public double N
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
        public double KoefU
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
        public AsyncCommand MainWindowProgramCalculateCommand { get; set; }
        #endregion

        public MainWindowProgramViewModel(/*IMathService mathService*/)
        {
            //Login = "researcher/admin";
            //Password = "researcher";

            //_mathService = mathService;
            MainWindowProgramCalculateCommand = new AsyncCommand(CalculateResults, CheckData);
        }

        #region Methods
        private async Task CalculateResults()
        {
            //длина=сервис.методсервиса
            _res = _mathService.Calculation(weight, height, lenght, ro, c, temp0, speedU, tempU, m0, b, tempR, n, koefU, step);


            //var sumResult = _mathService.SumTwoElement(1, 2);
            //Lenght = sumResult;//вывод на экран
        }
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

        private bool CheckData() => /*!string.IsNullOrEmpty(Login) && Password != null && */Lenght != null;

        #endregion


    }
}
