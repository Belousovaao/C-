using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Model.DAL;
using Model.Domain;

namespace Model;

public class UnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly DapperRepository _emps;

    public UnitOfWork()
    {
        _connectionString = "Data Source=localhost; Initial Catalog=DASamples; Integrated Security=True";
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
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                string cmdText = string.Join("\n",
                    new[] { _emps.GetUpdateScript()});
                var command = new SqliteCommand(cmdText, conn);
                command.ExecuteNonQuery();
            }
            Discard();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Discard()
    {
        _emps.Discard();

    }
}
