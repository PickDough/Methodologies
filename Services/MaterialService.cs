using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories.Abstract;
using Mappers;
using Model;

namespace Services.Abstract
{
    public class MaterialService: IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialMapper _mapper;

        public MaterialService()
        {
            _mapper = new MaterialMapper();
            _materialRepository = new MaterialRepository();
        }

        public Dictionary<MaterialModel, float> CalculateMaterials(List<OrderItemModel> orderItems)
        {
            Dictionary<MaterialModel, float> materialsAmount = new Dictionary<MaterialModel, float>();
            foreach (var item in  orderItems)
            {
                List<MaterialModel> usedMaterials = _materialRepository
                    .GetMaterialsInOrderItem(item.Id).Select(_mapper.MapToModel).ToList();
                foreach (MaterialModel material in usedMaterials)
                {
                    if (materialsAmount.ContainsKey(material))
                        materialsAmount[material] += 
                            material.UnitsPerArea * item.FrameParameters.Area * item.Quantity;
                    else
                        materialsAmount[material] =
                            material.UnitsPerArea * item.FrameParameters.Area * item.Quantity;
                }
                
            }

            return materialsAmount;
        }
    }
}