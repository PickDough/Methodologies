using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Data.UnitOfWork.Abstract;
using Domain;
using Mappers;
using Mappers.DomainToModel;
using Model;

namespace Services.Abstract
{
    public class MaterialService: IMaterialService
    {
        private readonly IUnitOfWork _uof;

        public MaterialService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public Dictionary<MaterialModel, float> CalculateMaterials(List<OrderItem> orderItems)
        {
            Dictionary<Material, float> materialsAmount = new Dictionary<Material, float>();
            foreach (var item in  orderItems)
            {
                List<Material> usedMaterials = _uof.MaterialRepository
                    .GetMaterialsInOrderItem(item.Id)
                    .Select(MaterialEntityDomainMapper.MapToDomain)
                    .ToList();
                foreach (Material material in usedMaterials)
                {
                    if (materialsAmount.ContainsKey(material))
                        materialsAmount[material] += 
                            material.UnitsPerArea * item.FrameParameters.Area * item.Quantity;
                    else
                        materialsAmount[material] =
                            material.UnitsPerArea * item.FrameParameters.Area * item.Quantity;
                }
                
            }

            return materialsAmount
                .ToDictionary(kp => MaterialDomainModelMapper.MapToModel(kp.Key),
                    kp => kp.Value);
        }
    }
}