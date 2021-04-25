using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Services.Abstract;
using WpfApp1.Directory;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class ClientSearchViewModel: BaseViewModel, IPageViewModel
    {
        private OrderModel _order;
        private string _searchText;
        private ObservableCollection<OrderModel> _orders;
        
        private IDialogService _dialogService;
        private IOrderService _orderService;
        private IServiceProvider _serviceProvider;
        
        public ClientSearchViewModel(IDialogService dialogService, IOrderService orderService, IServiceProvider serviceProvider)
        {
            _dialogService = dialogService;
            _orderService = orderService;
            _serviceProvider = serviceProvider;
            _orders = new(_orderService.GetAllOrders());
        }
        
        public OrderModel SelectedOrder
        {
            get => _order;
            set
            {
                _order = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<OrderModel> FilteredOrders
        {
            get
            {
                if (string.IsNullOrEmpty(SearchText))
                    return _orders;
                return new(_orders.Where(o => o.Client.StartsWith(SearchText)));
            }
        }
        
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SelectedOrder = null;
                NotifyPropertyChanged();
                NotifyPropertyChanged("FilteredOrders");
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
        }, _ => SelectedOrder != null && FilteredOrders.Count > 0);
    }
}