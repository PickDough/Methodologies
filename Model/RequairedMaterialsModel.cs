using System;
using System.Collections.Generic;

namespace Model
{
    public class RequiredMaterialsModel
    {
        public Guid OrderId { get; set; }
        public Dictionary<MaterialModel, float> RequiredMaterials { get; set; }
    }
}