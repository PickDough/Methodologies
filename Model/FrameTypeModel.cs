

namespace Model
{
    public class FrameTypeModel: Model
    {
        public string TypeName { get; set; }

        public override string ToString()
        {
            return $"{TypeName}";
        }
    }
}