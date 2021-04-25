using System.Windows;
using System.Windows.Input;
using Model;
using WpfApp1.View;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class OrderItemViewModel: DialogViewModelBase<OrderItemModel>
    {
        private OrderItemModel _orderItem;
        
        public OrderItemViewModel()
        {
            _orderItem = new OrderItemModel {FrameParameters = new FrameParametersModel()};
        }
        public OrderItemModel OrderItem
        {
            get => _orderItem;
            set
            {
                _orderItem = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Ok => new RelayCommand(o =>
        {
            IDialogWindow window = o as IDialogWindow;
            CloseDialogWithResult(window, OrderItem);
        }, _ => OrderItem.Validate());

    }
}