using System.Windows.Input;
using Domain;
using Model;
using Services.Abstract;
using WpfApp1.View;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class RequiredMaterialsViewModel: DialogViewModelBase<bool>
    {
        private readonly IOrderService _orderService;

        public RequiredMaterialsViewModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        public OrderModel Order { get; set; }

        public RequiredMaterialsModel RequiredMaterials => 
            _orderService.GetRequiredMaterials(Order.Id);
        
        public ICommand Ok => new RelayCommand(o =>
        {
            IDialogWindow window = o as IDialogWindow;
            CloseDialogWithResult(window, true);
        });
    }
}