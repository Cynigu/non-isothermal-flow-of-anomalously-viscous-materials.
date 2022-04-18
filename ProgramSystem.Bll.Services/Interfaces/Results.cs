namespace ProgramSystem.Bll.Services.Interfaces
{
    public class Results
    {
        public List<double> LengthOfCanal { get; set; }
        public List<double> TempInside { get; set; }
        public List<double> ViscosityInside { get; set; }
        public double Q { get; set; }
        public double T { get; set; }
        public double Visc { get; set; }

        public Results()
        {
            LengthOfCanal = new List<double>();
            TempInside = new List<double>();
            ViscosityInside = new List<double>();
        }
    }
}