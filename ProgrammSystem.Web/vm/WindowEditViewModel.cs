using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammSystem.Web.vm
{
    internal class WindowEditViewModel: ViewModelBase
    {
        #region Fields
        private string? login;
        private string? password;       

        private string? typeOfMaterial;
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


        #endregion

        public WindowEditViewModel()
        {
            
        }

        #region Methods
        

        #endregion




    }
}
