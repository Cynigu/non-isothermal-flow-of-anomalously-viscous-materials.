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

        public Results Calculation(double? W, double? H, double? L, double? ro, double? c, double? T0, double? Vu, double? Tu, double? mu0, double? b, double? Tr,
            double? n, double? alphau, double? step)
        {
            Results results = new Results();

            double F = 0.125 * Math.Pow((double)H / (double)W, 2) - 0.625 * (double)H / (double)W + 1;
            double Qc = (double)H * (double)W * (double)Vu * (double)F / 2;
            double Ydot = (double)Vu / (double)H;
            double qa = (double)W * (double)alphau * (Math.Pow((double)b, -1) - (double)Tu + (double)Tr);
            double qy = (double)H * (double)W * (double)mu0 * Math.Pow(Ydot, (double)n + 1);
            double T, nu;
            bool check = true;
            for(double i=0; i<=L; i+= (double)step)
            {
                results.LengthOfCanal.Add(i);
                T = (double)Tr + (1 / (double)b) * Math.Log(((double)b * qy + (double)W * (double)alphau) / ((double)b * qa) * (1 - Math.Exp(-(double)b * qa * i / ((double)ro * (double)c * (double)Qc))) 
                    + Math.Exp((double)b * ((double)T0 - (double)Tr - qa / ((double)ro * (double)c * (double)Qc)*i)));
                results.TempInside.Add(T);
                nu = (double)mu0 * Math.Exp(-(double)b * (T - (double)Tr)) * Math.Pow(Ydot, (double)n - 1);
                results.ViscosityInside.Add(nu);
                if (i + (double)step >= (double)L && check && Math.Round(i,2)!=L)
                {
                    i = (double)L- (double)step;
                    check = false;
                }
            }

            results.Q = (double)ro * Qc*3600;
            results.Visc = results.ViscosityInside[results.ViscosityInside.Count - 1];
            results.T = results.TempInside[results.TempInside.Count - 1];

            double speed, QcS, QS, YdotS, qyS, TS, nuS;
            check = true;

            for (double i = 0.01; i <= H; i += 0.01)
            {
                speed = (double)Vu / (double)H * i;
                results.SpeedInCanal.Add(speed);

                QcS = (double)H * (double)W * speed / 2 * F;
                QS = (double)ro * QcS * 3600;
                results.QWithSpeed.Add(QS);

                YdotS = (double)speed / (double)H;
                qyS = (double)H * (double)W * (double)mu0 * Math.Pow(YdotS, (double)n + 1);
                TS = (double)Tr + (1 / (double)b) * Math.Log(((double)b * qyS + (double)W * (double)alphau) / ((double)b * (double)qa) * (1 - Math.Exp(-(double)b * (double)qa * (double)L / ((double)ro * (double)c * QcS)))
                    + Math.Exp((double)b * ((double)T0 - (double)Tr - (double)qa / ((double)ro * (double)c * (double)QcS) * (double)L)));
                results.TempWithSpeed.Add(TS);

                nuS = (double)mu0 * Math.Exp(-(double)b * (TS - (double)Tr)) * Math.Pow(YdotS, (double)n - 1);
                results.ViscWithSpeed.Add(nuS);
               
                if (i + 0.01 > (double)H && check && Math.Round(i, 2) != H)
                {
                    i = (double)H - 0.01;
                    check = false;
                }
            }

            return results;
        }
    }
}
