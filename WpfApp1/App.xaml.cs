using System;
using System.Windows;
using Data.UnitOfWork;
using Data.UnitOfWork.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstract;
using WpfApp1.Directory;
using WpfApp1.ViewModel;

namespace WpfApp1
{
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
            serviceCollection.AddScoped<IDialogService, DialogService>();
            serviceCollection.AddSingleton<ApplicationView>();
            serviceCollection.AddSingleton(sp => sp);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationView app = _serviceProvider.GetService<ApplicationView>();
            app.Show();
        }
    }
}