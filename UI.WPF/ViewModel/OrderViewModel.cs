using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Services.Abstract;
using WpfApp1.Directory;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class OrderViewModel: BaseViewModel, IPageViewModel
    {
        private readonly IOrderService _orderService;
        private readonly IFrameService _frameService;
        private readonly IDialogService _dialogService;
        private readonly IServiceProvider _serviceProvider;
        
        private FrameModel _selectedFrame;
        private OrderModel _order;
        public OrderViewModel(IOrderService orderService, IFrameService frameService, IDialogService dialogService, IServiceProvider serviceProvider)
        {
            _orderService = orderService;
            _frameService = frameService;
            _dialogService = dialogService;
            _serviceProvider = serviceProvider;
            _order = new OrderModel() {OrderItems = new ObservableCollection<OrderItemModel>()};
        }

        public ICommand OrderItem => new RelayCommand(_ =>
        {
            var result = _dialogService.OpenFrameParametersDialog(
                _serviceProvider.GetService<OrderItemViewModel>());
            if (result != null)
            {
                result.Frame = SelectedFrame;
                OrderItems.Add(result);
            }
        }, _ => SelectedFrame != null);
        public ICommand FinishOrder => new RelayCommand(_ =>
        {
            ClientModel client = _dialogService.OpenClientDialog(
                _serviceProvider.GetService<ClientViewModel>());
            if (client != null)
            {
                _order.Client = client;
                _orderService.AddOrder(_order);
                _order = new OrderModel() {OrderItems = new ObservableCollection<OrderItemModel>()};
                OrderItems = _order.OrderItems;
            }
        }, _ => _order.OrderItems.Count > 0);

        public ObservableCollection<FrameModel> AvailableFrames => new(_frameService.GetAllFrames());

        public FrameModel SelectedFrame
        {
            get => _selectedFrame;
            set
            {
                _selectedFrame = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<OrderItemModel> OrderItems
        {
            get => _order.OrderItems;
            set
            {
                _order.OrderItems = value;
                NotifyPropertyChanged();
            }
        }
    }
}