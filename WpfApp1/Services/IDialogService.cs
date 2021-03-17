using System.Windows;
using WpfApplication1.ViewModel.Abstract;

namespace WpfApp1.Directory
{
    public interface IDialogService
    {
        T OpenFrameParametersDialog<T>(DialogViewModelBase<T> viewModel);
    }
}