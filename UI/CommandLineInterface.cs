using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using API;
using API.Abstract;
using Entities;
using Model;


namespace Methodology.LAB01.CLI
{
     public class CommandLineInterface
     {
         private readonly IManagerController _managerController;

         public CommandLineInterface()
         {
             _managerController = new ManagerController();
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
             OrderModel order = new OrderModel();
             order.OrderItems = new List<OrderItemModel>();
             
             Console.WriteLine("Choose any of the frames or type 0 to move next");
             List<FrameModel> frames = _managerController.AvailableFrames;
             while (true)
             {
                 LoadHeader();
                 int i = 0;
                 foreach (FrameModel frame in frames)
                 {
                     i++;
                     Console.WriteLine($"{i}. {frame.Name}");
                 }
    
                 int input = ReadNumber(0, i);
                 if (input == 0)
                     break;
                 OrderItemModel orderItem = new OrderItemModel();
                 orderItem.Frame = frames[i-1];
                 Console.WriteLine("Input widthxheight (10-200) of frame in separate inputs" +
                                   " and dwxdh (1-9) in separate inputs.");
                 FrameParametersModel frameParameters = new FrameParametersModel();
                 frameParameters.Width = ReadNumber(10, 200);
                 frameParameters.Height = ReadNumber(10, 200);
                 frameParameters.DWidth = ReadNumber(1, 9); 
                 frameParameters.DHeight = ReadNumber(1, 9);
                 Console.WriteLine("Input quantity of chosen frame (1-99)");
                 orderItem.Quantity = ReadNumber(1, 99);
                 orderItem.FrameParameters = frameParameters;
                 order.OrderItems.Add(orderItem);
             }
             if (order.OrderItems.Count > 0)
                _managerController.AddNewOrder(order);
         }

         public void DisplayMaterialsAmount()
         {
             List<OrderModel> orders = _managerController.CreatedOrders;
             LoadHeader();
             int i = 0;
             foreach (OrderModel order in orders)
             {
                 i++;
                 Console.WriteLine($"{i}. #{order.Id.ToString().Substring(0, 5)}");
             }
             if (i == 0)
                 return;
             int input = ReadNumber(1, i);
             RequiredMaterialsModel req = _managerController.CalculateRequiredMaterials(orders[input-1].Id);
             Console.WriteLine(req.OrderId.ToString().Substring(0, 5));
             Console.WriteLine(string.Join("\n", req.RequiredMaterials
                 .Select(d => $"{d.Key.MaterialType.TypeName} {d.Value}")));
         }
    
         public void LoadMenu()
         {
             LoadHeader();
             Console.WriteLine("1. Make new order.");
             Console.WriteLine("2. Calculate materials requirements for order.");
             int input = ReadNumber(1, 2);
             switch (input)
             {
                 case 1:
                     OrderItem();
                     break;
                 case 2:
                     DisplayMaterialsAmount();
                     break;
             }
             Console.WriteLine("");
             Console.WriteLine("Press enter to continue.");
             Console.ReadLine();
     }
         static void Main(string[] args)
         {

             CommandLineInterface cli = new CommandLineInterface();
             while (true)
             {
                 Console.Clear();
                 cli.LoadMenu();
             }
         }
    }
}