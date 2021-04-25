using System;
using System.Configuration;
using System.Windows;
using Data;
using Data.UnitOfWork;
using Data.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            Console.WriteLine();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = System.IO.Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine(projectDirectory);
            var builder = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        public IConfiguration Configuration { get; }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            //DbContext
            serviceCollection.AddDbContext<FrameDataContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("FrameDb")));
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