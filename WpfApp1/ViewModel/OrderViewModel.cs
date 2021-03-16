using System;
using System.Diagnostics;
using System.Windows.Input;
using Services.Abstract;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class OrderViewModel: BaseViewModel, IPageViewModel
    {
        private readonly IOrderService _orderService;
        private IFrameService _frameService;
        public OrderViewModel(IOrderService orderService, IFrameService frameService)
        {
            _orderService = orderService;
            _frameService = frameService;
        }
        public ICommand OrderItem => new RelayCommand(_ =>Console.WriteLine("you are fucking retarded"));
    }
}