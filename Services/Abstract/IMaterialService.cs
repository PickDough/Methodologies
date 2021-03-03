using System.Collections.Generic;
using Domain;
using Model;

namespace Services.Abstract
{
    public interface IMaterialService
    {
        public Dictionary<MaterialModel, float> CalculateMaterials(List<OrderItem> orderItems);
    }
}