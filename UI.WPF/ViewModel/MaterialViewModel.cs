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
    public class MaterialViewModel: BaseViewModel, IPageViewModel
    {
        private OrderModel _order;
        
        private IDialogService _dialogService;
        private IOrderService _orderService;
        private IServiceProvider _serviceProvider;
        public MaterialViewModel(IOrderService orderService, IDialogService dialogService, IServiceProvider serviceProvider)
        {
            _orderService = orderService;
            _dialogService = dialogService;
            _serviceProvider = serviceProvider;
        }

        public ObservableCollection<OrderModel> Orders =>
            new(_orderService.GetAllOrders());

        public OrderModel SelectedOrder
        {
            get => _order;
            set
            {
                _order = value;
                NotifyPropertyChanged();
            }
        }
        
        public ICommand ShowMaterials =>  new RelayCommand(_ =>
        {
            var viewModel = _serviceProvider.GetService<RequiredMaterialsViewModel>();
            if (viewModel != null)
            {
                viewModel.Order = SelectedOrder;
                _dialogService.OpenRequiredMaterialsDialog(viewModel);
            }
        }, _ => SelectedOrder != null);
        
    }
}