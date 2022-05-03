using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using ProgrammSystem.BLL.Autofac;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.Interfaces;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections.Generic;
using ProgramSystem.Bll.Services.DTO;

namespace ProgrammSystem.Web.vm
{
    public class MainWindowProgramViewModel: ViewModelBase
    {
        private readonly IMathService _mathService;
        private readonly IFileExcelService _fileExcelService;
        private readonly IMaterialService _materialService;
        private readonly IMaterialParameterValuesService _materialParameterValue;
        private Results? _res;
        #region Fields
        private double? lenght; //длина
        private double? weight;//ширина
        private double? height; //глубина

        private string? typeOfMaterial;
        private ICollection<MaterialDTO> typeMaterialList;
        private MaterialDTO currentTypeMaterial;
        private double? ro;
        private double? c;
        private double? temp0;

        private double? speedU;
        private double? tempU;

        private double? step;

        private double? m0;
        private double? b;
        private double? tempR;
        private double? n;
        private double? koefU;

        internal static Stopwatch sw;
        internal static long memory0;
        internal static Process pr;

        private bool checkCalculate;

        #endregion

        #region Properties

        public double? Lenght
        {
            get => lenght;
            set
            {
                if (value is null) lenght = 0;
                else lenght = value;
                OnPropertyChanged();
            }
        }
        public double? Weight
        {
            get => weight;
            set
            {
                if (value is null) weight = 0;
                else weight = value;
                OnPropertyChanged();
            }
        }
        public double? Height
        {
            get => height;
            set
            {
                if (value is null) height = 0;
                else height = value;
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
        public double? Ro
        {
            get => ro;
            set
            {
                if (value is null) ro = 0;
                else ro = value;
                OnPropertyChanged();
            }
        }
        public double? C
        {
            get => c;
            set
            {
                if (value is null) c = 0;
                else c = value;
                OnPropertyChanged();
            }          
        }
        public double? Temp0
        {
            get => temp0;
            set
            {
                if (value is null) temp0 = 0;
                else temp0 = value;
                OnPropertyChanged();
            }
        }
        public double? SpeedU
        {
            get => speedU;
            set
            {
                if (value is null) speedU = 0;
                else speedU = value;
                OnPropertyChanged();
            }
        }
        public double? TempU
        {
            get => tempU;
            set
            {
                if (value is null) tempU = 0;
                else tempU = value;
                OnPropertyChanged();
            }
        }
        public double? Step
        {
            get => step;
            set
            {
                if (value is null) step = 0;
                else step = value;
                OnPropertyChanged();
            }
        }
        public double? M0
        {
            get => m0;
            set
            {
                if (value is null) m0 = 0;
                else m0 = value;
                OnPropertyChanged();
            }
        }
        public double? B
        {
            get => b;
            set
            {
                if (value is null) b = 0;
                else b = value;
                OnPropertyChanged();
            }
        }
        public double? TempR
        {
            get => tempR;
            set
            {
                if (value is null) tempR = 0;
                else tempR = value;
                OnPropertyChanged();
            }
        }
        public double? N
        {
            get => n;
            set
            {
                if (value is null) n = 0;
                else n = value;
                OnPropertyChanged();
            }
        }
        public double? KoefU
        {
            get => koefU;
            set
            {
                if (value is null) koefU = 0;
                else koefU = value;
                OnPropertyChanged();
            }            
        }

        public bool CheckCalculate
        {
            get => checkCalculate;
            set
            {
                checkCalculate = value;
                OnPropertyChanged();
            }
        }

        public ICollection<MaterialDTO> TypeMaterialList
        {
            get => typeMaterialList;
            set
            {
                typeMaterialList = value;
                OnPropertyChanged();
            }
        }

        public MaterialDTO CurrentTypeMaterial
        {
            get => currentTypeMaterial;
            set
            {
                currentTypeMaterial = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand MainWindowProgramCalculateCommand { get; set; }
        public RelayCommand MainWindowProgramReportCommand { get; set; }
        #endregion

        public MainWindowProgramViewModel(IMathService mathService, IFileExcelService fileExcelService, IMaterialService materialService, IMaterialParameterValuesService materialParameterValue)
        {
            _mathService = mathService;
            _fileExcelService = fileExcelService;
            _materialService = materialService;
            _materialParameterValue = materialParameterValue;

            TypeOfMaterial = "Полипропилен";
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
            CheckCalculate = false;

            var param = _materialService.GetAllMaterialsObjectsAsync();

            ICollection<MaterialDTO> materials = param.Result;

            TypeMaterialList = materials;

            foreach (MaterialDTO material in materials)
            {
                CurrentTypeMaterial = material;
                break;
            }

            //var valuesMaterial = _materialParameterValue.GetAllMaterialParametrsValues();
            //ICollection<ParameterValue> val = valuesMaterial.Result;

            //foreach (ParameterValue values in val)
            //{
            //    string s = values.ParameterName;
            //    float f = values.Value;

            //    string h = s + f.ToString();
            //}


            MainWindowProgramCalculateCommand = new RelayCommand(obj => CalculateResults(), obj => !CanCalculate());

            MainWindowProgramReportCommand = new RelayCommand(obj => CreateReport(), obj => CheckCalculate);
        }

        #region Methods
        private void CalculateResults()
        {
            //длина=сервис.методсервиса
            _res = _mathService.Calculation(weight, height, lenght, ro, c, temp0, speedU, tempU, m0, b, tempR, n, koefU, step);

            sw = new Stopwatch();
            sw.Start();

            pr = Process.GetCurrentProcess();
            memory0 = pr.WorkingSet64;

            CheckCalculate=true;

            //новое окно как в апп хмл.кс
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();

            var viewmodelBase = new ResultWindowViewModel(_res, ref sw, ref memory0);
            var viewBase = new ResultWindow { DataContext = viewmodelBase };           

            viewBase.Show();

        }      

        private bool CanCalculate() => Weight<=0 || Height <=0 || Lenght <= 0 || Ro <= 0 || C <= 0 || Temp0 <= 0 || SpeedU <= 0 || TempU <= 0 || M0 <= 0 || B <= 0 || TempR <= 0 
            || N <= 0 || KoefU <= 0 || Step <= 0; //проверка

        private void CreateReport()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                if (_fileExcelService.CreateExcel(saveFileDialog.FileName, typeOfMaterial, weight, height, lenght, ro, c, temp0, speedU, tempU, m0, b, tempR, n, koefU, step, _res))
                    MessageBox.Show("Сохранение прошло успешно!");
                else MessageBox.Show("Произошла ошибка!");

        }


        #endregion


    }
}
