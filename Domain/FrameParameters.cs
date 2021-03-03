namespace Domain
{
    public class FrameParameters: Domain
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float DHeight { get; set; }
        public float DWidth { get; set; }
        
        public float Area => Width * Height - (Width - 2 * DWidth) * (Height - 2 * DHeight);
    }
}