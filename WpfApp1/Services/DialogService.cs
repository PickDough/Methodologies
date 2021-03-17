using Model;
using WpfApp1.Directory;
using WpfApp1.View;
using WpfApplication1.ViewModel.Abstract;

namespace WpfApp1.Services
{
    public class DialogService: IDialogService
    {
        public OrderItemModel OpenFrameParametersDialog(DialogViewModelBase<OrderItemModel> viewModel)
        {
            IDialogWindow window = new FrameParametersDialog();
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }

        public ClientModel OpenClientDialog(DialogViewModelBase<ClientModel> viewModel)
        {
            IDialogWindow window = new ClientView();
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }

        public bool OpenRequiredMaterialsDialog(DialogViewModelBase<bool> viewModel)
        {
            IDialogWindow window = new RequiredMaterialsView();
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}