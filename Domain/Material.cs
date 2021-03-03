namespace Domain
{
    public class Material: Domain
    {
        public MaterialType MaterialType { get; set; }
        public MaterialUnit MaterialUnits { get; set; }
        public int UnitsPerArea { get; set; }
        public int PricePerUnit { get; set; }
    }
}