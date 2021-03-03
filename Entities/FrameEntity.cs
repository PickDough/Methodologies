using System;
using System.Collections.Generic;
using Domain;

namespace Entities
{
    public class FrameEntity: Entity
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Description { get; set; }
        public Guid FrameTypeId { get; set; }
        public FrameTypeEntity FrameType { get; set; }
        public List<MaterialEntity> Materials { get; set; }
    }
}