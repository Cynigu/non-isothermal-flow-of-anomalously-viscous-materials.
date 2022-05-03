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
        public RelayCommand AddUserCommand { get; set; }

        #endregion

        public WindowEditViewModel(IUserService userService, IMaterialService materialService)
        {
            _userService = userService;
            _materialService = materialService;

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
                break;
            }

            AddUserCommand = new RelayCommand(obj => AddUser(), obj => CanAddUser());
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

        private void AddUser()
        {
            UserDTO newUser = new UserDTO { Login=Login, Password=Password, Role=CurrentRole};
            var user = _userService.AddUserAsync(newUser);
            if (user.Status == TaskStatus.Faulted)
            {
                MessageBox.Show("Перепроверьте введенные данные!");
            }

            var listUserDB = _userService.GetAllUsers();
            List<UserDTO> u = new List<UserDTO>();
            List<string> role = new List<string>();
            foreach (var user1 in listUserDB)
            {
                u.Add(user1);
            }
            UserList = u;

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

        private bool CanAddUser() => Login is not null && Password is not null && CurrentRole is not null; //проверка



    }
}
