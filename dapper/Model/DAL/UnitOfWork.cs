using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Model.DAL;
using Model.Domain;

namespace Model;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseConnection _connectionString;
    private readonly DapperRepository _emps;

    public UnitOfWork()
    {
        _connectionString = new DataBaseConnection("Data Source=/Users/Anna/Desktop/C#/Repos-vscode/C-/dapper/ConsoleApp1/Emps.db;");
        _emps = new DapperRepository(_connectionString);
    }

    public IRepository<Employee> Emps
    {
        get { return _emps; }
    }

    public bool SaveChanges()
    {
        try
        {
            _emps.ExecuteUpdates();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while saving changes: " + ex.Message); // Логируем сообщение об ошибке
            return false;
        }
    }

    public void Discard()
    {
        _emps.Discard();

    }
}
