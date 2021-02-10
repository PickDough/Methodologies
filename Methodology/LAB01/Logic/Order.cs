using System;
using System.Collections.Generic;
using System.Linq;

namespace Methodology.LAB01
{
    public class Order
    {
        public string Id { get; }
        
        public Dictionary<IProduct, int> OrderItems { get; }

        public string OrderInfo => string.Join('\n', OrderItems
            .Select(t => t.Key.Info)
            .ToList());

        public string OrderDescription => string.Join('\n', OrderItems
            .Select(t => t.Key.Description)
            .ToList());

        public Dictionary<IMaterial, float> TotalMaterials
        {
            get
            {
                Dictionary<IMaterial, float> result = new Dictionary<IMaterial, float>();
                foreach (Tuple<IMaterial, float> item in OrderItems
                    .SelectMany(d => d.Key.MaterialsAmount(d.Value)))
                {
                    if (result.ContainsKey(item.Item1))
                    {
                        result[item.Item1] += item.Item2;
                    }
                    else
                    {
                        result[item.Item1] = item.Item2;
                    }
                }

                return result;
            }
        }

        public float TotalPrice => OrderItems.Sum(d => d.Key.Price * d.Value);
    }
}