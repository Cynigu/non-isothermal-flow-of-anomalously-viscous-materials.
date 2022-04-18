using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IMathService
    {
        //vtnjls rjnjhst z [jxe gjkexbnm
        //гетленгбайматериалнаме (что передаю ((название материала))

        // int SumTwoElement(int x, int y);

        public Results Calculation(double w, double h, double l, double ro, double c, double T0, double Vu, double Tu, double mu0, double b, double Tr, double n, double alphau, double step);
    }
}
