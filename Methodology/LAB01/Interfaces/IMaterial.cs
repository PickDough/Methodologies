namespace Methodology.LAB01
{
    public interface IMaterial
    {
        public string Type { get; set; }
        public string Units { get; set; }
        public float CalculateUnits(float amount);
        public float CalculatePrice(float amount);
    }
}