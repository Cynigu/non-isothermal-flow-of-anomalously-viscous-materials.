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
        public List<double> SpeedInCanal { get; set; }
        public List<double> QWithSpeed { get; set; }
        public List<double> TempWithSpeed { get; set; }
        public List<double> ViscWithSpeed { get; set; }
        public Results()
        {
            LengthOfCanal = new List<double>();
            TempInside = new List<double>();
            ViscosityInside = new List<double>();
            SpeedInCanal = new List<double>();
            QWithSpeed = new List<double>();
            TempWithSpeed = new List<double>();
            ViscWithSpeed = new List<double>();
        }
    }
}