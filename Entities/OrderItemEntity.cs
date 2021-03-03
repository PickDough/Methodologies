using System;
using Domain;

namespace Entities
{
    public class OrderItemEntity: Entity
    {
        public Guid FrameId { get; set; }
        public FrameEntity Frame { get; set; }
        public Guid FrameParametersId { get; set; }
        public FrameParametersEntity FrameParameters { get; set; }
        public int Quantity { get; set; }
    }
}