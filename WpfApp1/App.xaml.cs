using System;
using System.Windows;
using Data.UnitOfWork;
using Data.UnitOfWork.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstract;
using WpfApp1.ViewModel;
using WpfApplication1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUnitOfWork,UnitOfWork>();
            serviceCollection.AddScoped<IMaterialService, MaterialService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<IFrameService, FrameService>();
            serviceCollection.AddScoped<ApplicationViewModel>();
            serviceCollection.AddScoped<OrderViewModel>();
            serviceCollection.AddScoped<NavigationViewModel>();
            serviceCollection.AddScoped<ClientViewModel>();
            serviceCollection.AddScoped<MaterialViewModel>();
            serviceCollection.AddSingleton<ApplicationView>();
            serviceCollection.AddSingleton(sp => sp);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // IUnitOfWork _uof = new UnitOfWork();
            // IMaterialService _materialService = new MaterialService(_uof);
            // IOrderService _orderService = new OrderService(_uof, _materialService);
            // IFrameService _frameService = new FrameService(_uof);
            //
            // OrderViewModel _order = new OrderViewModel(_orderService, _frameService);
            // ClientViewModel _client = new ClientViewModel();
            // MaterialViewModel _material = new MaterialViewModel();
            // NavigationViewModel _navigation = new NavigationViewModel();
            
            ApplicationView app = _serviceProvider.GetService<ApplicationView>();
            app.Show();
        }
    }
}