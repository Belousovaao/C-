using ConsoleApp1;
using Model.BL;
using Model.DAL;
using Model.Domain;
using Presenter;
using Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
        private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<Employee>();
        services.AddSingleton<IRepository<Employee>, EntityRepository<Employee>>();
        services.AddSingleton<IMainModel, MainModel>();
        services.AddSingleton<IMainView, MainView>();
        return services;
    }
    
    private static void Main(string[] args)
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        var model = serviceProvider.GetService<IMainModel>();
        var view = serviceProvider.GetService<IMainView>();

        using (var db = new DataContext())
        {
            db.Database.EnsureCreated();
        }

        var presenter = new MainPresenter(model, view);
    }
}