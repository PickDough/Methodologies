using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Mappers.DomainToModel;
using Model;

namespace Services.Abstract
{
    public class MaterialService: IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialEntityDomainMapper _entityDomainMapper;
        private readonly IMaterialDomainModelMapper _domainModelMapper;

        public MaterialService()
        {
            _entityDomainMapper = new MaterialEntityDomainMapper();
            _materialRepository = new MaterialRepository();
            _domainModelMapper = new MaterialDomainModelMapper();
        }

        public Dictionary<MaterialModel, float> CalculateMaterials(List<OrderItem> orderItems)
        {
            Dictionary<Material, float> materialsAmount = new Dictionary<Material, float>();
            foreach (var item in  orderItems)
            {
                List<Material> usedMaterials = _materialRepository
                    .GetMaterialsInOrderItem(item.Id)
                    .Select(_entityDomainMapper.MapToDomain)
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
                .ToDictionary(kp => _domainModelMapper.MapToModel(kp.Key),
                    kp => kp.Value);
        }
    }
}