namespace Model
{
    public class MaterialTypeModel: Model
    {
        public string TypeName { get; set; }

        public override string ToString()
        {
            return $"{TypeName}";
        }
    }
}