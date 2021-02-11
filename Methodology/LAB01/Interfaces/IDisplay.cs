using Methodology.LAB01.DAO;

namespace Methodology.LAB01
{
    public interface IDisplay
    {
        public Order Order { get;  }
        public Warehouse Warehouse { get; }

        public void LoadMenu();
        public void OrderItem();
        public void DisplayItemsInfo();
        public void DisplayItemsDescription();
        public void DisplayItemsPrice();
        public void DisplayMaterialsPrice();
    }
}