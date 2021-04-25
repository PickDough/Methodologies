using System.Windows;
using Model;
using WpfApplication1.ViewModel.Abstract;

namespace WpfApp1.Directory
{
    public interface IDialogService
    {
        OrderItemModel OpenFrameParametersDialog(DialogViewModelBase<OrderItemModel> viewModel);
        ClientModel OpenClientDialog(DialogViewModelBase<ClientModel> viewModel);
        bool OpenRequiredMaterialsDialog(DialogViewModelBase<bool> viewModel);

    }
}