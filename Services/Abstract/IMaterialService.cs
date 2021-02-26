using System.Collections.Generic;
using Model;

namespace Services.Abstract
{
    public interface IMaterialService
    {
        public Dictionary<MaterialModel, float> CalculateMaterials(List<OrderItemModel> orderItems);
    }
}