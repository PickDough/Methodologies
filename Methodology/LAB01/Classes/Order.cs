using System;
using System.Collections.Generic;
using System.Linq;

namespace Methodology.LAB01
{
    public class Order
    {
        public int count { get; set; }

        public Order()
        {
            count = 0;
            OrderItems = new Dictionary<IProduct, int>();
        }
        
        public Dictionary<IProduct, int> OrderItems { get; }

        public string OrderInfo(bool single)
        {
            if (single)
                return string.Join('\n', OrderItems
                .Select(t => $"{t.Key.Info()} for single item.")
                .ToList());
            return string.Join('\n', OrderItems
                .Select(t => $"{t.Key.Info(t.Value)} for {t.Value} item(s).")
                .ToList());
        }

        public string OrderDescription() => string.Join('\n', OrderItems
            .Select(t => $"{t.Key.Info()} \n"+t.Key.Description)
            .ToList());

        public Dictionary<IMaterial, float> TotalMaterials()
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

        public float TotalPrice() => OrderItems.Sum(d => d.Key.Price * d.Value);
    }
}