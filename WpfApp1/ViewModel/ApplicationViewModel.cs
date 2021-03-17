using System;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class ApplicationViewModel: BaseViewModel, IPageViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private IPageViewModel _currentViewModel;

        public ApplicationViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _currentViewModel = _serviceProvider.GetService<NavigationViewModel>();
        }
        public IPageViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand DisplayNavigationView => new RelayCommand(_ =>
            CurrentViewModel = _serviceProvider.GetService<NavigationViewModel>());
        public ICommand DisplayOrderView => new RelayCommand(_ => 
            CurrentViewModel = _serviceProvider.GetService<OrderViewModel>());
        public ICommand DisplayMaterialView => new RelayCommand(_ => 
            CurrentViewModel = _serviceProvider.GetService<MaterialViewModel>());
        public ICommand DisplayClientView => new RelayCommand(_ => 
            {});
    }
}