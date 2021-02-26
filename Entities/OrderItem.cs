using System;
using Domain;

namespace Entities
{
    public class OrderItem: Entity
    {
        public Guid FrameId { get; set; }
        public Frame Frame { get; set; }
        public Guid FrameParametersId { get; set; }
        public FrameParameters FrameParameters { get; set; }
        public int Quantity { get; set; }
    }
}