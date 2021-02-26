using System;
using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class Material: Entity
    {
        public Guid MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }
        public Guid MaterialUnitsId { get; set; }
        public MaterialUnit MaterialUnits { get; set; }
        public int UnitsPerArea { get; set; }
        public int PricePerUnit { get; set; }
        public List<Frame> Frames { get; set; }
    }
}