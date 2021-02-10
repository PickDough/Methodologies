using System;
using System.Collections.Generic;
using System.Linq;

namespace Methodology.LAB01
{
    public class Frame : IProduct
    {
        public float Width { get; set; }
        public float dWidth { get; set;  }
        
        public float Height { get; set; }
        public float dHeight { get; set; }
        
        public List<Material> Materials { get; }
        
        public Frame(float width, float dWidth, float height, float dHeight)
        {
            Width = width;
            this.dWidth = dWidth;
            Height = height;
            this.dHeight = dHeight;
            Materials = new List<Material>();
        }

        public float Area => Height * Width - (Height - 2 * dHeight) * (Width - 2 * dWidth);

        public float Price => Materials.Sum(m => m.CalculatePrice(Area));
        public string Info { get; }
        public string Description { get; }


        public List<Tuple<IMaterial, float>> MaterialsAmount()
        {
            return Materials
                    .Select(m => new Tuple<IMaterial, float>(m, m.CalculateUnits(Area)))
                    .ToList();
        }

        public List<Tuple<IMaterial, float>> MaterialsAmount(int amount)
        {
            return Materials
                .Select(m => new Tuple<IMaterial, float>(m, amount * m.CalculateUnits(Area)))
                .ToList();
        }
    }
}