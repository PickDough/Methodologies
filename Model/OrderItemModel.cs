using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Model
{
    public class OrderItemModel: Model, IDataErrorInfo
    {
        public OrderItemModel(): base() {}
        public FrameModel Frame { get; set; }
        public FrameParametersModel FrameParameters { get; set; }
        public int Quantity { get; set; }
        public string Error { get; }

        public string this[string name]
        {
            get
            {
                string result = null;
                if (name == "Quantity")
                {
                    if (!ValidateQuantity())
                        result = "Quantity should be between 1 and 99";
                }

                return result;
            }
        }

        private bool ValidateQuantity()
        {
            return 1 <= Quantity && Quantity <= 99;
        }

        public bool Validate()
        {
            return ValidateQuantity() && FrameParameters.Validate();
        }

        public override string ToString()
        {
            return $"{Frame?.Name}: {FrameParameters}, {Quantity} items";
        }
    }
}