using System;
using System.Linq;
using System.Xml.Schema;
using Methodology.LAB01.DAO;

namespace Methodology.LAB01.CLI
{
    public class CommandLineInterface: IDisplay
    {
        public Order Order { get; }

        public Warehouse Warehouse { get; }

        public CommandLineInterface(Order order, Warehouse warehouse)
        {
            Order = order;
            Warehouse = warehouse;
        }
        private void LoadHeader()
        {
            Console.WriteLine("FRAMESHOP"); 
            Console.WriteLine("Choose one of the following options by typing a specified number");
        }

         private int ReadNumber(int start, int end)
        {
            int number;
            while (true)
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out number))
                    if (number<=end && number>=start)
                        return number;
                Console.WriteLine($"Input correct number between {start} and {end}");
            }
        }

        public void OrderItem()
        {
            Console.WriteLine("Input widthxheight (10-200) of frame in separate inputs" +
                              " and dwxdh (1-9) in separate inputs.");
            Frame frame = new Frame("Custom Frame" + Order.count, ReadNumber(10, 200), ReadNumber(10, 200),
                ReadNumber(1, 9), ReadNumber(1, 9));
            Console.WriteLine("Choose any of the materials or type 0 to move next");
            while (true)
            {
                LoadHeader();
                int i = 1;
                foreach (Material m in Warehouse.Materials)
                {
                    Console.WriteLine($"{i}. {m}");
                    i++;
                }

                int input = ReadNumber(0, Warehouse.Materials.Count);
                if (input == 0)
                    break;
                frame.Materials.Add(Warehouse.Materials[input-1]);
            }

            if (frame.Materials.Count == 0)
            {
                Console.WriteLine("Can't add frame without any material.");
            }
            else
            {
                Console.WriteLine("How many items do you want to order? (1-99)");
                Order.OrderItems[frame] = ReadNumber(1, 99);
                Order.count++;
            }
        }

        public void DisplayItemsInfo()
        {
            Console.WriteLine(Order.OrderInfo(false));
            Console.WriteLine("Do you wish to view Price for single frame? (1) Yes | (2) No");
            int input = ReadNumber(1, 2);
            if (input == 1)
                Console.WriteLine(Order.OrderInfo(true));
        }

        public void DisplayItemsDescription()
        {
            Console.WriteLine(Order.OrderDescription());
        }

        public void DisplayItemsPrice()
        {
            Console.WriteLine($"Price of your order is {Order.TotalPrice()}$");
        }

        public void DisplayMaterialsPrice()
        {
            Console.WriteLine(string.Join("\n", Order.TotalMaterials()
                .Select(d => $"{d.Key}: {d.Value}{d.Key.Units}")));
        }

        public void LoadMenu()
        {
            LoadHeader();
            Console.WriteLine("1. Order new frame.");
            Console.WriteLine("2. View your current Order.");
            Console.WriteLine("3. View description of your current Order.");
            Console.WriteLine("4. Calculate Price of your Order.");
            Console.WriteLine("5. Calculate amount of required materials.");
            int input = ReadNumber(1, 5);
            switch (input)
            {
                case 1:
                    OrderItem();
                    break;
                case 2:
                    DisplayItemsInfo();
                    break;
                case 3:
                    DisplayItemsDescription();
                    break;
                case 4:
                    DisplayItemsPrice();
                    break;
                case 5:
                    DisplayMaterialsPrice();
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
    }
        static void Main(string[] args)
        {
            Order order = new Order();
            Warehouse warehouse = new Warehouse();
            warehouse.InitializeMaterials();
            Frame fr1 = new Frame("Golden Lake", 120, 100, 8, 8);
            fr1.Materials.Add(warehouse.Materials[0]);
            fr1.Materials.Add(warehouse.Materials[4]);
            fr1.Materials.Add(warehouse.Materials[6]);
            Frame fr2 = new Frame("Wooden Ring", 150, 140, 6, 6);
            fr2.Materials.Add(warehouse.Materials[0]);
            fr2.Materials.Add(warehouse.Materials[3]);
            fr2.Materials.Add(warehouse.Materials[5]);
            order.OrderItems.Add(fr1, 2);
            order.OrderItems.Add(fr2, 1);
           
            CommandLineInterface cli = new CommandLineInterface(order, warehouse);
            while (true)
            {
                Console.Clear();
                cli.LoadMenu();
            }
        }
    }
}