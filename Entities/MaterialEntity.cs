using System;
using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class MaterialEntity: Entity
    {
        public Guid MaterialTypeId { get; set; }
        public MaterialTypeEntity MaterialType { get; set; }
        public Guid MaterialUnitsId { get; set; }
        public MaterialUnitEntity MaterialUnits { get; set; }
        public int UnitsPerArea { get; set; }
        public int PricePerUnit { get; set; }
        public List<FrameEntity> Frames { get; set; }
    }
}