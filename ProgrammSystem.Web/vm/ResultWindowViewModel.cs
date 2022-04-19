using ProgramSystem.Bll.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammSystem.Web.vm
{
    internal class ResultWindowViewModel
    {
        private Results _res;
        #region Fields
        private string? temp; 
        private string? visc;
        private string? q;

        private List<double> len;
        private List<double> tempIn;
        private List<double> viscIn;

        #endregion

        #region Properties      
        public string? Temp
        {
            get
            {
                return temp;
            }
            set
            {
                temp = value;
            }
        }
        public string? Q
        {
            get
            {
                return q;
            }
            set
            {
                q = value;
            }
        }
        public string? Visc
        {
            get
            {
                return visc;
            }
            set
            {
                visc = value;
            }
        }

        public List<double> Len
        {
            get
            {
                return len;
            }
            set
            {
                len = value;
            }
        }
        public List<double> TempIn
        {
            get
            {
                return tempIn;
            }
            set
            {
                tempIn = value;
            }
        }
        public List<double> ViscIn
        {
            get
            {
                return viscIn;
            }
            set
            {
                viscIn = value;
            }
        }
        #endregion

        #region Commands
        #endregion

        public ResultWindowViewModel(Results res)
        {
            _res = res;

            Temp = "Температура = " + Math.Round(res.T, 2).ToString() + " С";
            Q = "Производительность = " + Math.Round(res.Q, 2).ToString() + " кг/ч";
            Visc = "Вязкость = " + Math.Round(res.Visc, 2).ToString() + " Па*с";

            Len = res.LengthOfCanal;
            TempIn = res.TempInside;
            ViscIn = res.ViscosityInside;

            

            
        }

        #region Methods        

        #endregion

    }
}
