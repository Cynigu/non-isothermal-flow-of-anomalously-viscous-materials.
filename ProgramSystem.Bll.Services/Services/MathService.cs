using ProgramSystem.Bll.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgramSystem.Bll.Services.Services
{
    public class MathService : IMathService
    {
        //реализация сервиса

        public Results Calculation(double W, double H, double L, double ro, double c, double T0, double Vu, double Tu, double mu0, double b, double Tr, double n, double alphau, double step)
        {
            Results results = new Results();

            double F = 0.125 * Math.Pow(H / W, 2) - 0.625 * H / W + 1;
            double Qc = H * W * Vu * F / 2;
            double Ydot = Vu / H;
            double qa = W * alphau * (Math.Pow(b, -1) - Tu + Tr);
            double qy = H * W * mu0 * Math.Pow(Ydot, n + 1);
            double T, nu;
            bool check = true;
            for(double i=0; i<=L; i+=step)
            {
                results.LengthOfCanal.Add(i);
                T = Tr + (1 / b) * Math.Log((b * qy + W * alphau) / (b * qa) * (1 - Math.Exp(-b * qa * i / (ro * c * Qc))) + Math.Exp(b * (T0 - Tr - qa / (ro * c * Qc))));
                results.TempInside.Add(T);
                nu = mu0 * Math.Exp(-b * (T - Tr)) * Math.Pow(Ydot, n - 1);
                results.ViscosityInside.Add(nu);
                if (i + step > L && check)
                {
                    i = L;
                    check = false;
                }
            }

            results.Q = ro * Qc;
            results.Visc = results.ViscosityInside[results.ViscosityInside.Count - 1];
            results.T = results.TempInside[results.TempInside.Count - 1];
            return results;
        }
    }
}
