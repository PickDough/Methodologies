using System;
using System.Collections.Generic;

namespace Methodology.LAB01
{
    public interface IProduct
    {
        public float Price { get; }
        public string Info { get; }
        public string Description { get; }
        public List<IMaterial> Materials { get; }

        public List<Tuple<IMaterial, float>> MaterialsAmount();
        public List<Tuple<IMaterial, float>> MaterialsAmount(int productsAmount);
    }
}