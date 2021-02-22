using Methodology.LAB01.Interfaces;

namespace Methodology.LAB01.Classes
{
    public class DataContext
    {
        public IDataContainer<Order> Orders;
        public IDataContainer<Frame> Frames;
        public IDataContainer<Material> Materials;
    }
}