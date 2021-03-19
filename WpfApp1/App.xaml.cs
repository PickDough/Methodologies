using System;
using System.Windows;
using Data;
using Data.UnitOfWork;
using Data.UnitOfWork.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstract;
using WpfApp1.Directory;
using WpfApp1.Services;
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
            //DbContext
            serviceCollection.AddDbContext<FrameDataContext>();
            //Services
            serviceCollection.AddSingleton<IUnitOfWork,UnitOfWork>();
            serviceCollection.AddSingleton<IMaterialService, MaterialService>();
            serviceCollection.AddSingleton<IOrderService, OrderService>();
            serviceCollection.AddSingleton<IFrameService, FrameService>();
            serviceCollection.AddSingleton<IDialogService, DialogService>();
            serviceCollection.AddSingleton(sp => sp);
            //ViewModel
            serviceCollection.AddTransient<ApplicationViewModel>();
            serviceCollection.AddTransient<OrderViewModel>();
            serviceCollection.AddTransient<NavigationViewModel>();
            serviceCollection.AddTransient<ClientViewModel>();
            serviceCollection.AddTransient<MaterialViewModel>();
            serviceCollection.AddTransient<ClientSearchViewModel>();
            serviceCollection.AddTransient<OrderItemViewModel>();
            serviceCollection.AddTransient<RequiredMaterialsViewModel>();
            //Application
            serviceCollection.AddSingleton<ApplicationView>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationView app = _serviceProvider.GetService<ApplicationView>();
            app.Show();
        }
    }
}