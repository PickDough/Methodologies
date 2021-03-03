namespace Domain
{
    public class OrderItem: Domain
    {
        public Frame Frame { get; set; }
        public FrameParameters FrameParameters { get; set; }
        public int Quantity { get; set; }
    }
}