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
using System;
using System.Data;

namespace ProgrammSystem.Web.vm
{
    public class MainWindowProgramViewModel: ViewModelBase
    {
        private readonly IMathService _mathService;
        private readonly IFileExcelService _fileExcelService;
        private readonly IMaterialService _materialService;
        private readonly IMaterialParameterValuesService _materialParameterValue;
        private readonly IEmpiricalParameterValuesService _empiricalParameterValue;
        private readonly IParameterService _parameterService;
        private Results? _res;
        #region Fields
        private double? lenght; //длина
        private double? weight;//ширина
        private double? height; //глубина

        private string? typeOfMaterial;
        private ICollection<MaterialDTO> typeMaterialList;
        private MaterialDTO currentTypeMaterial;
        private int currentIdMaterial;
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

        private DataTable dtParameters;

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
                CurrentIdMaterial = value.Id;
                UpdateTextBox(CurrentIdMaterial);
                OnPropertyChanged();
                UpdateDT(CurrentIdMaterial);
            }
        }
        public int CurrentIdMaterial
        {
            get => currentIdMaterial;
            set
            {
                currentIdMaterial = value;
                OnPropertyChanged();
            }
        }

        public DataTable DTParameters
        {
            get
            {
                return dtParameters;
            }
            set
            {
                dtParameters = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Commands
        public RelayCommand MainWindowProgramCalculateCommand { get; set; }
        public RelayCommand MainWindowProgramReportCommand { get; set; }
        #endregion

        public MainWindowProgramViewModel(IMathService mathService, IFileExcelService fileExcelService, IMaterialService materialService, IMaterialParameterValuesService materialParameterValue, IEmpiricalParameterValuesService empiricalParameterValue, IParameterService parameterService)
        {
            _mathService = mathService;
            _fileExcelService = fileExcelService;
            _materialService = materialService;
            _materialParameterValue = materialParameterValue;
            _empiricalParameterValue = empiricalParameterValue;
            _parameterService = parameterService;
            Lenght = 7.5;
            Weight = 0.2;
            Height = 0.003;
            SpeedU =1.5;
            TempU =180;
            Step =1;
            CheckCalculate = false;

            var param = _materialService.GetAllMaterialsObjectsAsync();

            ICollection<MaterialDTO> materials = param.Result;

            TypeMaterialList = materials;

            foreach (MaterialDTO material in materials)
            {
                CurrentTypeMaterial = material;
                break;
            }

            int id = CurrentIdMaterial;

            UpdateTextBox(id);

            MainWindowProgramCalculateCommand = new RelayCommand(obj => CalculateResults(), obj => !CanCalculate());

            MainWindowProgramReportCommand = new RelayCommand(obj => CreateReport(), obj => CheckCalculate);

            //UpdateDT(id);
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
                if (_fileExcelService.CreateExcel(saveFileDialog.FileName, CurrentTypeMaterial.Name, weight, height, lenght, ro, c, temp0, speedU, tempU, m0, b, tempR, n, koefU, step, _res))
                    MessageBox.Show("Сохранение прошло успешно!");
                else MessageBox.Show("Произошла ошибка!");

        }

        private void UpdateTextBox(int id)
        {
            var parametersMaterialTask = _materialParameterValue.GetAllMaterialParametersValuesByIdMaterialId(id);
            ICollection<ParameterValue> parameterValues = parametersMaterialTask.Result;
            foreach (ParameterValue p in parameterValues)
            {
                switch (p.ParameterName)
                {
                    case "Плотность, ρ":
                        Ro = p.Value;
                        break;
                    case "Удельная теплоемкость, c":
                        C = p.Value;
                        break;
                    case "Температура плавления, T0":
                        Temp0 = p.Value;
                        break;
                }
            }
            var parametersEmphTask = _empiricalParameterValue.GetEmpiricalParametersValuesByIdMaterialId(id);
            parameterValues = parametersEmphTask.Result;
            foreach (ParameterValue p in parameterValues)
            {
                switch (p.ParameterName)
                {
                    case "Коэффициент консистенции материала при температуре приведения, μ0":
                        M0 = p.Value;
                        break;
                    case "Температурный коэффициент вязкости материала, b":
                        B = Math.Round(p.Value, 3);
                        break;
                    case "Температура приведения, Tr":
                        TempR = p.Value;
                        break;
                    case "Индекс течения материала, n":
                        N = Math.Round(p.Value, 3);
                        break;
                    case "Коэффициент теплоотдачи от крышки канала к материалу, Tu":
                        KoefU = p.Value;
                        break;
                }
            }
        }

        private /*async*/ void UpdateDT(int id)
        {
            DataTable DTParameters1 = new DataTable();
            DTParameters = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            DTParameters1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ed";
            DTParameters1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "value";
            DTParameters1.Columns.Add(column);

            //await _parameterService.GetAllParametersObjectsByTypeParameterAsync();
            var f = _empiricalParameterValue.GetEmpiricalParametersValuesByIdMaterialId(CurrentTypeMaterial.Id).Result;
           
            foreach (ParameterValue par in f)
            {
                switch (par.ParameterName) {
                    //case "Ширина, W":
                    //    break;
                    //case "Длина, H":
                    //      break;
                    //  case "Глубина, L":
                    //      break;
                    //  case "Плотность, ρ":
                    //      break;
                    //  case "Удельная теплоемкость, c":
                    //      break;
                    //  case "Температура плавления, T0":
                    //      break;
                    //  case "Скорость крышки, Vu":
                    //      break;
                    //  case "Температура крышки, Tu":
                          //break;
                      case "Коэффициент консистенции материала при температуре приведения, μ0":
                          break;
                      case "Температурный коэффициент вязкости материала, b":
                          break;
                      case "Температура приведения, Tr":
                          break;
                      case "Индекс течения материала, n":
                          break;
                      case "Коэффициент теплоотдачи от крышки канала к материалу, Tu":
                          break;
                    default:
                        row = DTParameters1.NewRow();
                        row["name"]=par.ParameterName;
                        row["ed"] = par.UnitOfMeasName;
                        row["value"] = Math.Round(par.Value,3);
                        DTParameters1.Rows.Add(row);
                        break;
                }

            }
            DTParameters = DTParameters1;
           
            
        }



        #endregion


    }
}
