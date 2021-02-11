namespace Methodology.LAB01
{
    public class Material : IMaterial
    {
        public string Type { get; set; }
        public string Units { get; set; }
        public float UnitsPerArea { get; set; }
        
        public float PricePerUnit { get; set; }
        
        public Material(string type, string units, float unitsPerArea, float pricePerUnit)
        {
            Type = type;
            Units = units;
            UnitsPerArea = unitsPerArea;
            PricePerUnit = pricePerUnit;
        }

        public float CalculateUnits(float area)
        {
            return UnitsPerArea * area;
        }

        public float CalculatePrice(float area)
        {
            return PricePerUnit * UnitsPerArea * area;
        }

        public override string ToString()
        {
            return $"{Type}";
        }
    }
}