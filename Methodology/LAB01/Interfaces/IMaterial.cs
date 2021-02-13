namespace Methodology.LAB01
{
    public interface IMaterial
    {
        public string Type { get;}
        public string Units { get;}
        public float CalculateUnits(float amount);
        public float CalculatePrice(float amount);
    }
}