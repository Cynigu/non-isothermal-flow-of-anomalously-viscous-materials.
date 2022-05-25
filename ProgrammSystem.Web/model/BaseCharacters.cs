using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammSystem.Web.model
{
    public class BaseCharacters
    {
        public BaseCharacters(double lenght,
                              double weight,
                              double height,
                              double ro,
                              double c,
                              double temp0,
                              double step,
                              double m0,
                              double b,
                              double tempR,
                              double n,
                              double koefU)
        {
            Lenght = lenght;
            Weight = weight;
            Height = height;
            Ro = ro;
            C = c;
            Temp0 = temp0;
            Step = step;
            M0 = m0;
            B = b;
            TempR = tempR;
            N = n;
            KoefU = koefU;
        }

        public double Lenght
        {
            get; set;
        }
        public double Weight
        {
            get; set;
        }
        public double Height
        {
            get; set;
        }
        public double Ro
        {
            get; set;
        }
        public double C
        {
            get; set;
        }
        public double Temp0
        {
            get; set;
        }
        public double Step
        {
            get;set;
        }
        public double M0
        {
            get;set;
        }
        public double B
        {
            get; set;
        }
        public double TempR
        {
            get; set;
        }
        public double N
        {
            get; set;
        }
        public double KoefU
        {
            get; set;
        }
    }
}
