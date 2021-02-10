using System;
using System.Collections.Generic;
using System.Linq;

namespace Methodology.LAB01
{
    public class Frame : IProduct
    {
        public string Name { get; set; }
        public float Width { get; set; }
        public float dWidth { get; set;  }
        
        public float Height { get; set; }
        public float dHeight { get; set; }
        
        public List<IMaterial> Materials { get; }
        
        public Frame(string name, float width, float height, float dWidth, float dHeight)
        {
            Name = name;
            Width = width;
            this.dWidth = dWidth;
            Height = height;
            this.dHeight = dHeight;
            Materials = new List<IMaterial>();
        }

        public float Area => Height * Width - (Height - 2 * dHeight) * (Width - 2 * dWidth);

        public float Price => Materials.Sum(m => m.CalculatePrice(Area));
        public string Info => $"Frame \"{Name}\" {Width}x{Height}(cm) {Price}$";

        public string Description => string.Join("\n", MaterialsAmount()
            .Select(t => $"{t.Item1}: {t.Item2}{t.Item1.Units}")
            .ToList());


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