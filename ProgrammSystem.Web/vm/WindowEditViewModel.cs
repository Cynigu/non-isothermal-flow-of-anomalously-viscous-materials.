using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using ProgrammSystem.BLL.Autofac;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Data.Repository.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProgrammSystem.Web.vm
{
    internal class WindowEditViewModel: ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IMaterialService _materialService;
        private readonly IMaterialParameterValuesService _materialParameterValue;
        private readonly IEmpiricalParameterValuesService _empiricalParameterValue;
        private readonly IUnitOfMeasService _unitOfMeasService;
        private readonly IParameterService _parameterService;
        private readonly SqlLiteRepositoryContextFactory _factory;
        #region Fields
        private string? login;
        private string? password;
        private List<UserDTO> userList;
        private UserDTO selectUser;
        private List<string> roleList;
        private string currentRole;

        private ICollection<MaterialDTO> materialList;
        private MaterialDTO currentMaterial;
        private int currentMaterialId;
        private string? nameMaterial;

        //private string? typeOfMaterial;
        //private ICollection<MaterialDTO> typeMaterialList;
        //private MaterialDTO currentTypeMaterial;
        //private int currentIdMaterial;

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

        private string? namePar;
        private ICollection<ParameterDTO> parametersList;
        private ParameterDTO currentParameter;
        private int currentParameterId;

        private ICollection<UnitOfMeasDTO> unitList;
        private UnitOfMeasDTO currentUnit;
        private int currentUnitId;
        private string? nameUnit;

        private ICollection<string> typeParametersList;
        private string currentTypeParameter;

        private List<ParameterValue> parametersValueList;
        private ParameterValue currentParameterValue;
        private double valueP;

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
        public List<UserDTO> UserList
        {
            get => userList;
            set
            {
                userList = value;
                OnPropertyChanged();
            }
        }
        public UserDTO SelectUser
        {
            get => selectUser;
            set
            {
                selectUser = value;
                OnPropertyChanged();
                OnSelect_UserChange();
            }
        }
        public List<string> RoleList
        {
            get => roleList;
            set
            {
                roleList = value;
                OnPropertyChanged();
            }
        }
        public string CurrentRole
        {
            get
            {
                return currentRole;
            }
            set
            {
                currentRole = value;
                OnPropertyChanged();
            }
        }

        public ICollection<MaterialDTO> MaterialList
        {
            get => materialList;
            set
            {
                materialList = value;
                OnPropertyChanged();
            }
        }
        public MaterialDTO CurrentMaterial
        {
            get => currentMaterial;
            set
            {
                currentMaterial = value;
                if (currentMaterial is not null)
                {
                    nameMaterial = currentMaterial.Name;
                    CurrentMaterialId = currentMaterial.Id;
                    NameMaterial=currentMaterial.Name;
                    UpdateTableValue();
                }
                OnPropertyChanged();
            }
        }
        public int CurrentMaterialId
        {
            get => currentMaterialId;
            set
            {
                currentMaterialId = value;
                OnPropertyChanged();
            }
        }
        public string? NameMaterial
        {
            get
            {
                return nameMaterial;
            }
            set
            {
                nameMaterial = value;
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

        public string? NamePar
        {
            get
            {
                return namePar;
            }
            set
            {
                namePar = value;
                OnPropertyChanged();
            }
        }
        public ICollection<ParameterDTO> ParametersList
        {
            get => parametersList;
            set
            {
                parametersList = value;
                OnPropertyChanged();
            }
        }
        public ParameterDTO CurrentParameter
        {
            get => currentParameter;
            set
            {
                currentParameter = value;
                if (currentParameter is not null)
                {
                    currentParameterId = currentParameter.Id;
                    NamePar = currentParameter.Name;
                }
                if(ParametersValueList is not null)
                {
                    foreach(ParameterValue p in ParametersValueList)
                    {
                        if (currentMaterial.Id == p.MaterialId && currentParameterId == p.ParameterId) Value = Math.Round(p.Value,3);
                    }
                }
                OnPropertyChanged();
            }
        }
        public int CurrentParameterId
        {
            get => currentParameterId;
            set
            {
                currentParameterId = value;
                OnPropertyChanged();
            }
        }

        public ICollection<UnitOfMeasDTO> UnitList
        {
            get => unitList;
            set
            {
                unitList = value;
                OnPropertyChanged();
            }
        }
        public UnitOfMeasDTO CurrentUnit
        {
            get => currentUnit;
            set
            {
                currentUnit = value;
                if (currentUnit is not null)
                {
                    NameUnit = currentUnit.Name;
                    CurrentUnitId = currentUnit.Id;
                }
                OnPropertyChanged();
            }
        }
        public int CurrentUnitId
        {
            get => currentUnitId;
            set
            {
                currentUnitId = value;
                OnPropertyChanged();
            }
        }
        public string? NameUnit
        {
            get
            {
                return nameUnit;
            }
            set
            {
                nameUnit = value;
                OnPropertyChanged();
            }
        }

        public ICollection<string> TypeParametersList
        {
            get => typeParametersList;
            set
            {
                typeParametersList = value;
                OnPropertyChanged();
            }
        }
        public string CurrentTypeParameter
        {
            get => currentTypeParameter;
            set
            {
                currentTypeParameter = value;
                OnPropertyChanged();
            }
        }

        public List<ParameterValue> ParametersValueList
        {
            get => parametersValueList;
            set
            {
                parametersValueList = value;
                OnPropertyChanged();
            }
        }
        public ParameterValue CurrentParamValue
        {
            get => currentParameterValue;
            set
            {
                currentParameterValue = value;
                if (currentParameterValue is not null)
                {
                    CurrentMaterialId = currentParameterValue.MaterialId;
                    foreach (MaterialDTO m in MaterialList)
                    {
                        if (m.Id == CurrentMaterialId) { CurrentMaterial = m; break; }
                    }

                    foreach (ParameterDTO p in ParametersList)
                    {
                        if (p.Id == currentParameterValue.ParameterId) { CurrentParameter = p; break; }
                    }
                    Value = Math.Round(currentParameterValue.Value,3);
                }
                OnPropertyChanged();
            }
        }
        public double Value
        {
            get
            {
                return valueP;
            }
            set
            {
                valueP = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Commands 
        public AsyncCommand AddUserCommand { get; set; }
        public AsyncCommand DeleteUserCommand { get; set; }
        public AsyncCommand EditUserCommand { get; set; }

        public AsyncCommand AddMaterialCommand { get; set; }
        public AsyncCommand DeleteMaterialCommand { get; set; }
        public AsyncCommand EditMaterialCommand { get; set; }

        public AsyncCommand AddParameterCommand { get; set; }
        public AsyncCommand DeleteParameterCommand { get; set; }
        public AsyncCommand EditParameterCommand { get; set; }

        public AsyncCommand AddUnitCommand { get; set; }
        public AsyncCommand DeleteUnitCommand { get; set; }
        public AsyncCommand EditUnitCommand { get; set; }

        public AsyncCommand AddValueCommand { get; set; }
        public AsyncCommand DeleteValueCommand { get; set; }
        public AsyncCommand EditValueCommand { get; set; }
        public AsyncCommand BackupCommand { get; set; }

        #endregion

        public WindowEditViewModel(IUserService userService, IMaterialService materialService, IMaterialParameterValuesService materialParameterValuesService, IEmpiricalParameterValuesService empiricalParameterValuesService, IUnitOfMeasService unitOfMeasService,
            IParameterService parameterService, SqlLiteRepositoryContextFactory contextFactory)
        {
            _userService = userService;
            _materialService = materialService;
            _materialParameterValue = materialParameterValuesService;
            _empiricalParameterValue = empiricalParameterValuesService;
            _unitOfMeasService = unitOfMeasService;
            _parameterService = parameterService;
            _factory = contextFactory;

            var listUserDB = _userService.GetAllUsers();
            List<UserDTO> u = new List<UserDTO>();
            List<string> role = new List<string>();
            foreach (var user in listUserDB)
            {
                u.Add(user);
                if(!role.Contains(user.Role)) role.Add(user.Role);
            }
            UserList=u;
            RoleList = role;
            //добавление ролей

            //материал          
            var param = _materialService.GetAllMaterialsObjectsAsync();
            ICollection<MaterialDTO> materials = param.Result;
            MaterialList = materials;
            foreach (MaterialDTO material in materials)
            {
                CurrentMaterial = material;
                CurrentMaterialId = material.Id;
                break;
            }           

            //комбобокс ед. измерения
            var paramUnit = _unitOfMeasService.GetAllUnitOfMeasObjectAsync();
            ICollection<UnitOfMeasDTO> units = paramUnit.Result;
            UnitList = units;
            foreach (UnitOfMeasDTO unit in units)
            {
                CurrentUnit = unit;
                break;
            }

            //комбобокс типы параметров
            var paramTypePar = _parameterService.GetAllParameterTypesAsync();
            ICollection<string> typeParNames = paramTypePar.Result;
            List<string> typeParMaterialL = new List<string>();
            foreach (string type in typeParNames)
            {
                if (type == "Параметры свойств материала" || type == "Эмпирические коэффициенты математической модели")
                {
                    typeParMaterialL.Add(type);
                }
            }
            TypeParametersList = typeParMaterialL;
            foreach (string type in typeParNames)
            {
                CurrentTypeParameter = type;
                break;
            }

            var paramPar = _parameterService.GetAllParametersObjectsByTypeParameterAsync();
            ICollection<ParameterDTO> parameters = paramPar.Result;
            List<ParameterDTO> parMaterialL = new List<ParameterDTO>();
            foreach (ParameterDTO paramet in parameters)
            {
                if (paramet.TypeParameter == "Параметры свойств материала" || paramet.TypeParameter == "Эмпирические коэффициенты математической модели")
                {
                    parMaterialL.Add(paramet);
                }
            }
            ParametersList = parMaterialL;

            var materValM = _materialParameterValue.GetAllMaterialParametersValuesByIdMaterialId(CurrentMaterial.Id);
            ICollection <ParameterValue> MVal = materValM.Result;
            var materValE = _empiricalParameterValue.GetEmpiricalParametersValuesByIdMaterialId(CurrentMaterial.Id);
            ICollection<ParameterValue> EVal = materValE.Result;
            List<ParameterValue> valMater = new List<ParameterValue>();
            foreach(ParameterValue mbox in MVal)
            {
                valMater.Add(mbox);
            }
            foreach (ParameterValue mbox in EVal)
            {
                valMater.Add(mbox);
            }
            ParametersValueList= valMater;

            AddUserCommand = new AsyncCommand(AddUser, CanUser);
            DeleteUserCommand = new AsyncCommand(DeleteUser, CanUser);
            EditUserCommand = new AsyncCommand(EditUser, CanUser);

            AddMaterialCommand = new AsyncCommand(AddMaterial, CanMaterialAdd);
            DeleteMaterialCommand = new AsyncCommand(DeleteMaterial, CanMaterialDel);
            EditMaterialCommand = new AsyncCommand(EditMaterial, CanMaterialEdit);

            AddParameterCommand = new AsyncCommand(AddParameter, CanParameterAdd);
            DeleteParameterCommand = new AsyncCommand(DeleteParameter, CanParameterDel);
            EditParameterCommand = new AsyncCommand(EditParameter, CanParameterEdit);

            AddUnitCommand = new AsyncCommand(AddUnit, CanUnitAdd);
            DeleteUnitCommand = new AsyncCommand(DeleteUnit, CanUnitDel);
            EditUnitCommand = new AsyncCommand(EditUnit, CanUnitEdit);

            AddValueCommand = new AsyncCommand(AddValue, CanValueAddEdit);
            DeleteValueCommand = new AsyncCommand(DeleteValue, CanValueDel);
            EditValueCommand = new AsyncCommand(EditValue, CanValueAddEdit);

            BackupCommand = new AsyncCommand(BackupCreate, CanBackup);
        }

        #region Methods


        #endregion

        public void OnSelect_UserChange()
        {
            if(SelectUser is not null)
            {
                Login = SelectUser.Login;
                Password = SelectUser.Password;
                CurrentRole = SelectUser.Role;
            }
            
        }

        private async Task AddUser()
        {
            UserDTO newUser = new UserDTO { Login=Login, Password=Password, Role=CurrentRole};
            await _userService.AddUserAsync(newUser);
            UpdateTableUser();

            //var user = _userService.GetAccountByLoginPassword(Login ?? "", new NetworkCredential("", Password).Password);
            //var users = _userService.GetAllUsers();
            //string uString = "";
            //var builderBase = new ContainerBuilder();

            //builderBase.RegisterModule(new ContextFactoriesModule());
            //builderBase.RegisterModule(new ServicesModule());

            //var containerBase = builderBase.Build();
            ////foreach (var u in users)
            ////{
            ////    uString += u.Id + " Логин: " + u.Login + " Роль: " + u.Role +"\n";
            ////}
            ////MessageBox.Show(uString);
        }

        private bool CanUser() => Login is not null && Password is not null && CurrentRole is not null; //проверка

        private bool CanUnitAdd() => NameUnit is not null && NameUnit!=""; //проверка
        private bool CanUnitEdit() => CurrentUnit is not null && NameUnit is not null && NameUnit != ""; //проверка
        private bool CanUnitDel() => CurrentUnit is not null; //проверка

        private bool CanMaterialAdd() => NameMaterial is not null && NameMaterial != ""; //проверка
        private bool CanMaterialEdit() => CurrentMaterial is not null && NameMaterial is not null && NameMaterial != ""; //проверка
        private bool CanMaterialDel() => CurrentMaterial is not null; //проверка

        private bool CanParameterAdd() => NamePar is not null && NamePar != "" && CurrentTypeParameter is not null && CurrentUnit is not null; //проверка
        private bool CanParameterEdit() => NamePar is not null && NamePar != "" && CurrentTypeParameter is not null && CurrentUnit is not null && CurrentParameter is not null; //проверка
        private bool CanParameterDel() => CurrentParameter is not null; //проверка

        private bool CanValueAddEdit() => CurrentMaterial is not null  && CurrentParameter is not null  && Value > 0; //проверка
        private bool CanValueDel() => CurrentMaterial is not null && CurrentParameter is not null; //проверка

        private bool CanBackup() => true;
        private async Task DeleteUser()
        {
            UserDTO oldU = SelectUser;
            if (oldU is not null)
            {
                await _userService.RemoveRangeAsync(new int[] { oldU.Id });
                
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableUser();
        }
        
        private async Task EditUser()
        {
            UserDTO newUser = new UserDTO { Login = Login, Password = Password, Role = CurrentRole };
            UserDTO oldUser = SelectUser;
            if (oldUser is not null)
            {
                await _userService.EditUser(newUser.Login, newUser.Password, oldUser.Id, newUser.Role);                
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableUser();
        }

        private async void UpdateTableUser()
        {
            var listUserDB = /*await */_userService.GetAllUsers();
            List<UserDTO> u = new List<UserDTO>();
            List<string> role = new List<string>();
            foreach (var user1 in listUserDB)
            {
                u.Add(user1);
            }
            UserList = u;
        }

        private async Task AddMaterial()
        {
            await _materialService.AddMaterialByNameAsync(NameMaterial);
            UpdateTableMaterial();
        }
        private async void UpdateTableMaterial()
        {
            var listMaterial = _materialService.GetAllMaterialsObjectsAsync();
            MaterialList = listMaterial.Result;
        }

        private async Task DeleteMaterial()
        {
            MaterialDTO oldU = CurrentMaterial;
            if (oldU is not null)
            {
                await _materialService.RemoveMaterialByIdAsync(CurrentMaterial.Id);
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableMaterial();
        }

        private async Task EditMaterial()
        {
            MaterialDTO oldUnit = CurrentMaterial;
            string s = NameMaterial;
            if (oldUnit is not null)
            {
                await _materialService.EditMatrial(CurrentMaterial.Id, s);
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableMaterial();
        }

        private async Task AddParameter()
        {
            ParameterDTO param = new ParameterDTO { Name= NamePar, TypeParameter=CurrentTypeParameter, UnitOfMeasName=CurrentUnit.Name};
            await _parameterService.AddParameterAsync(param);
            UpdateTableParameter();
        }
        private async void UpdateTableParameter()
        {
            var paramPar = _parameterService.GetAllParametersObjectsByTypeParameterAsync();
            ICollection<ParameterDTO> parameters = paramPar.Result;
            List<ParameterDTO> parMaterialL = new List<ParameterDTO>();
            foreach (ParameterDTO paramet in parameters)
            {
                if (paramet.TypeParameter == "Параметры свойств материала" || paramet.TypeParameter == "Эмпирические коэффициенты математической модели")
                {
                    parMaterialL.Add(paramet);
                }
            }
            ParametersList = parMaterialL;
        }

        private async Task DeleteParameter()
        {
            ParameterDTO oldP = CurrentParameter;
            if (oldP is not null)
            {
                await _parameterService.RemoveParameterByIdAsync(oldP.Id);
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableParameter();
        }

        private async Task EditParameter()
        {
            int curId = CurrentParameter.Id;
            if (CurrentParameter is not null)
            {
                await _parameterService.EditParameter(curId, CurrentTypeParameter, NamePar, CurrentUnit.Id);
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableParameter();
        }

        private async Task AddUnit()
        {;
            await _unitOfMeasService.AddUnitOfMeasByDescriptionAsync(NameUnit);
            UpdateTableUnit();
        }
        private async void UpdateTableUnit()
        {
            var listUnit = _unitOfMeasService.GetAllUnitOfMeasObjectAsync();
            var listUnitDB = listUnit.Result;
            List<UnitOfMeasDTO> u = new List<UnitOfMeasDTO>();
            foreach (var unitF in listUnitDB)
            {
                u.Add(unitF);
            }
            UnitList = u;
        }

        private async Task DeleteUnit()
        {
            UnitOfMeasDTO oldU = CurrentUnit;
            if (oldU is not null)
            {
                await _unitOfMeasService.RemoveUnitOfMeasByIdAsync(CurrentUnit.Id);

            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableUnit();
        }

        private async Task EditUnit()
        {         
            UnitOfMeasDTO oldUnit = CurrentUnit;
            string s = NameUnit;
            if (oldUnit is not null)
            {
                await _unitOfMeasService.EditUnitOfMeas(oldUnit.Id, s);
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTableUnit();
        }

        private async Task AddValue()
        {
            ParameterValue newVal = new ParameterValue
            {
                MaterialId = CurrentMaterial.Id,
                MaterialName = CurrentMaterial.Name,
                ParameterId = CurrentParameter.Id,
                ParameterName = CurrentParameter.Name,
                ParameterType = CurrentParameter.TypeParameter,
                UnitOfMeasName = CurrentParameter.UnitOfMeasName,
                Value = (float)Value
            };
            if (CurrentParameter.TypeParameter == "Параметры свойств материала")
            {                
                await _materialParameterValue.AddMaterialParameter(newVal);
            }
            else
            {
                await _empiricalParameterValue.AddEmpiricalParameter(newVal);
            }
            UpdateTableValue();
        }
        private async void UpdateTableValue()
        {
            var materValM = _materialParameterValue.GetAllMaterialParametersValuesByIdMaterialId(CurrentMaterial.Id);
            ICollection<ParameterValue> MVal = materValM.Result;
            var materValE = _empiricalParameterValue.GetEmpiricalParametersValuesByIdMaterialId(CurrentMaterial.Id);
            ICollection<ParameterValue> EVal = materValE.Result;
            List<ParameterValue> valMater = new List<ParameterValue>();
            foreach (ParameterValue mbox in MVal)
            {
                valMater.Add(mbox);
            }
            foreach (ParameterValue mbox in EVal)
            {
                valMater.Add(mbox);
            }
            ParametersValueList = valMater;
        }

        private async Task DeleteValue()
        {
            if (CurrentParameter.TypeParameter == "Параметры свойств материала")
            {
                await _materialParameterValue.DeleteMaterialParameterValue(CurrentParameter.Id, CurrentMaterial.Id);
            }
            else
            {
                await _empiricalParameterValue.DeleteEmpiricalParameterValue(CurrentParameter.Id, CurrentMaterial.Id);
            }

            UpdateTableValue();
        }

        private async Task EditValue()
        {
            if (CurrentParameter.TypeParameter == "Параметры свойств материала")
            {
                await _materialParameterValue.EditMaterialParameterValue(CurrentParameter.Id, CurrentMaterial.Id, (float)Value);
            }
            else
            {
                await _empiricalParameterValue.EditEmpiricalParameterValue(CurrentParameter.Id, CurrentMaterial.Id, (float)Value);
            }

            UpdateTableValue();
        }

        private async Task BackupCreate()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                SqliteConnection sqliteConnection = new SqliteConnection("Data Source = rpkDB.db.db");
                SqliteCommand sqlCmd = sqliteConnection.CreateCommand();
                sqlCmd.CommandText = $"VACUUM INTO '{ saveFileDialog.FileName + ".db"}'";
                sqliteConnection.Open();
                sqlCmd.ExecuteNonQuery();
                sqliteConnection.Close();

                MessageBox.Show("Сохранение прошло успешно!");
            }
            
        }
    }
}
