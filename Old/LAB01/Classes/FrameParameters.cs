using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Methodology.LAB01.Classes
{
    public class FrameParameters
    {
        public Guid Id { get; }
        public float Width { get; }
        public float dWidth { get; }
        public float Height { get; }
        public float dHeight { get; }
        public float Area { get; }

        public FrameParameters(float width, float dwidth, float height, float dheight)
        {
            Width = width;
            dWidth = dwidth;
            Height = height;
            dHeight = dheight;
            Area = Width * Height - (Width - 2 * dWidth) * (Height - 2 * dHeight);
        }
    }
}