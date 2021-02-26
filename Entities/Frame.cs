using System;
using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class Frame: Entity
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Description { get; set; }
        public Guid FrameTypeId { get; set; }
        public FrameType FrameType { get; set; }
        public List<Material> Materials { get; set; }
    }
}