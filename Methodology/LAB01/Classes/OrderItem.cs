using System;

namespace Methodology.LAB01.Classes
{
    public class OrderItem: ContainerItem
    {
        public Frame Product { get; }
        public int Quantity { get; }
        public FrameParameters FrameParameters { get; }

        public OrderItem(Frame product, int quantity, FrameParameters parameters)
        {
            Product = product;
            Quantity = quantity;
            FrameParameters = parameters;
        }
    }
}