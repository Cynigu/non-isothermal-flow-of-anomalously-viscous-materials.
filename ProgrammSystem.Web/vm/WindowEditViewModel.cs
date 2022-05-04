using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        #region Fields
        private string? login;
        private string? password;
        private List<UserDTO> userList;
        private UserDTO selectUser;
        private List<string> roleList;
        private string currentRole;

        private string? typeOfMaterial;
        private ICollection<MaterialDTO> typeMaterialList;
        private MaterialDTO currentTypeMaterial;
        private int currentIdMaterial;

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

        private string? name;
        private string? unit; //ед изм
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
                currentIdMaterial = value.Id;
                UpdateTextBox(currentIdMaterial);
                OnPropertyChanged();
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

        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string? Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Commands 
        public AsyncCommand AddUserCommand { get; set; }
        public AsyncCommand DeleteUserCommand { get; set; }
        public AsyncCommand EditUserCommand { get; set; }

        #endregion

        public WindowEditViewModel(IUserService userService, IMaterialService materialService, IMaterialParameterValuesService materialParameterValuesService, IEmpiricalParameterValuesService empiricalParameterValuesService)
        {
            _userService = userService;
            _materialService = materialService;
            _materialParameterValue = materialParameterValuesService;
            _empiricalParameterValue = empiricalParameterValuesService;

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

            //комбобокс материала
            var param = _materialService.GetAllMaterialsObjectsAsync();
            ICollection<MaterialDTO> materials = param.Result;
            TypeMaterialList = materials;
            foreach (MaterialDTO material in materials)
            {
                CurrentTypeMaterial = material;
                CurrentIdMaterial = material.Id;
                break;
            }
            int id = CurrentIdMaterial;
            UpdateTextBox(id);

            AddUserCommand = new AsyncCommand(AddUser, CanUser);
            DeleteUserCommand = new AsyncCommand(DeleteUser, CanUser);
            EditUserCommand = new AsyncCommand(EditUser, CanUser);
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
            UpdateTable();

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

        private async Task DeleteUser()
        {
            UserDTO oldU = SelectUser;
            if (oldU is not null)
            {
                await _userService.RemoveRangeAsync(new int[] { oldU.Id });
                
            }
            else MessageBox.Show("Перепроверьте введенные данные!");

            UpdateTable();
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

            UpdateTable();
        }

        private async void UpdateTable()
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

    }
}
