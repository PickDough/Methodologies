using System.Collections.Generic;

namespace Methodology.LAB01.DAO
{
    public class Warehouse
    {
        public List<IMaterial> Materials { get; }

        public Warehouse()
        {
            Materials = new List<IMaterial>();
        }

        public void InitializeMaterials()
        {
            Material gold = new Material("Gold", "kg", 0.2f, 1000);
            Material silver = new Material("Silver", "kg", 0.2f, 600);
            Material wood1 = new Material("Dark Oak", "kg", 0.5f, 100);
            Material wood2 = new Material("Indian Cork", "kg", 0.6f, 150);
            Material glass = new Material("Layered Glass", "m^2", 1, 350);
            Material paint = new Material("Paint", "ml", 600, 0.5f);
            Material larnish = new Material("Larnish", "ml", 400, 0.65f);
            Materials.Add(gold);
            Materials.Add(silver);
            Materials.Add(wood1);
            Materials.Add(wood2);
            Materials.Add(glass);
            Materials.Add(paint);
            Materials.Add(larnish);
        }
    }
}