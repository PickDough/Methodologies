using System.Windows;
using WpfApp1.View;
using WpfApplication1.ViewModel.Abstract;

namespace WpfApp1.Directory
{
    public class DialogService: IDialogService
    {
        public T OpenFrameParametersDialog<T>(DialogViewModelBase<T> viewModel)
        {
            IDialogWindow window = new FrameParametersDialog();
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}