namespace Model
{
    public class OrderItemModel: Model
    {
        public FrameModel Frame { get; set; }
        public FrameParametersModel FrameParameters { get; set; }
        public int Quantity { get; set; }
    }
}