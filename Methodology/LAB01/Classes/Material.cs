using System;

namespace Methodology.LAB01
{
    public class Material
    {
        public Guid Id { get; }
        public MaterialType MaterialType { get; }
        public MaterialUnits Units { get;  }
        public float UnitsPerArea { get; }
        public float PricePerUnit { get;}
    }

    public enum MaterialType
    {
        Wood, Glass, Silver, Gold, Paint, Larnish
    }

    public enum MaterialUnits
    {
        gr, ml
    }
}