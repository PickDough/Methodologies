using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
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
        
        private FrameModel _selectedFrame;
        private OrderModel _order;
        public OrderViewModel(IOrderService orderService, IFrameService frameService, IDialogService dialogService)
        {
            _orderService = orderService;
            _frameService = frameService;
            _dialogService = dialogService;
            _order = new OrderModel() {OrderItems = new ObservableCollection<OrderItemModel>()};
        }

        public ICommand OrderItem => new RelayCommand(_ =>
        {
            var result = _dialogService.OpenFrameParametersDialog(
                new OrderItemViewModel("Order Details", "Please specify size of frame."));
            if (result != null)
            {
                result.Frame = SelectedFrame;
                OrderItems.Add(result);
            }
        }, _ => SelectedFrame != null);
        public ICommand FinishOrder => new RelayCommand(_ =>
        {
            _orderService.AddOrder(_order);
            _order = new OrderModel() {OrderItems = new ObservableCollection<OrderItemModel>()};
        });

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