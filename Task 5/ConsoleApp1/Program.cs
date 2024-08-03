using ConsoleApp1;
using Model.BL;
using Model.DAL;
using Model.Domain;
using Ninject;
using Ninject.Modules;
using Presenter;
using Shared;

internal class Program
{
    private static void Main(string[] args)
    {
        IRepository<Employee> repository = new FakeRepository<Employee>();
        IMainModel model = new MainModel(repository);
        IMainView view = new MainView(model);
        MainPresenter presenter = new MainPresenter(model, view);
        view.Run();
    }
}
