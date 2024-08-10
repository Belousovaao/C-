using ConsoleApp1;
using Model.BL;
using Model.DAL;
using Model.Domain;
using Presenter;
using Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Microsoft.VisualBasic;

internal class Program
{
    public static void Main(string[] args)
    {
        IMainModel model = new MainModel();
        IMainView view = new MainView(model);
        MainPresenter presenter = new MainPresenter(model, view);
    }
}