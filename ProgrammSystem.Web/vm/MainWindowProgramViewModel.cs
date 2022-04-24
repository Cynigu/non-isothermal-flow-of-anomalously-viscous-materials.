using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using ProgrammSystem.BLL.Autofac;
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
        public RelayCommand MainWindowProgramCalculateCommand { get; set; }
        #endregion

        public MainWindowProgramViewModel(IMathService mathService)
        {
            _mathService = mathService;

            Lenght = 7.5;
            Weight = 0.2;
            Height = 0.003;
            Ro =900;
            C =2230;
            Temp0 =172;
            SpeedU =1.5;
            TempU =180;
            Step =1;
            M0 =1500;
            B =0.014;
            TempR =185;
            N =0.38;
            KoefU =1500;

            MainWindowProgramCalculateCommand = new RelayCommand(obj => CalculateResults(), obj => true);
        }

        #region Methods
        private void CalculateResults()
        {
            //длина=сервис.методсервиса
            _res = _mathService.Calculation(weight, height, lenght, ro, c, temp0, speedU, tempU, m0, b, tempR, n, koefU, step);

            //новое окно как в апп хмл.кс
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();

            var viewmodelBase = new ResultWindowViewModel(_res);
            var viewBase = new ResultWindow { DataContext = viewmodelBase };

            viewBase.Show();

        }      

        private bool CanCalculate() => Weight<=0 || Height <=0 || Lenght <= 0 || Ro <= 0 || C <= 0 || Temp0 <= 0 || SpeedU <= 0 || TempU <= 0 || M0 <= 0 || B <= 0 || TempR <= 0 
            || N <= 0 || KoefU <= 0 || Step <= 0; //проверка

        #endregion


    }
}
