using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.DAL;
using Model.Domain;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class DapperRepository : AdoRepository<Employee>
{
    private readonly DataBaseConnection _connectionString;
    
    public DapperRepository(DataBaseConnection connectionString)
    {
        _connectionString = connectionString;
    }

    public override IEnumerable<Employee> GetAll()
    {
        var employees = new List<Employee>();
        
        foreach (var employee in Added)
        {
            yield return employee;
        }

        using (var conn = _connectionString.GetConnection())
        {
            conn.Open();
            string cmdText = "SELECT Id, Name, Age FROM Emps";
            if (Deleted.Count > 0)
            {
                cmdText += $"WHERE Id NOT IN ({string.Join(",", DeletedIds)})";
            }
            employees.AddRange(conn.Query<Employee>(cmdText));
        }

        foreach (var employee in employees)
        {
            yield return employee;
        }
    }
    public override string GetUpdateScript()
    {
        var scripts = new List<string>();
        if (Deleted.Count > 0)
        {
            string delScriptTemplate = "DELETE FROM Emps WHERE Id IN ({0})";
            scripts.Add(string.Format(delScriptTemplate, string.Join(",", DeletedIds)));
        }
        string addScriptTemplate = "INSERT INTO Emps (Name, Age) VALUES(@Name, @Age);";
        foreach (var employee in Added)
        {
            scripts.Add(addScriptTemplate);
        }
        return string.Join("\n", scripts);
    }

    public void ExecuteUpdates()
    {
        using (var conn = _connectionString.GetConnection())
        {
            conn.Open();
        
            if (Deleted.Count > 0)
            {
                string deleteSql = $"DELETE FROM Emps WHERE Id IN ({string.Join(",", DeletedIds)})";
                conn.Execute(deleteSql);
            }

            foreach (var employee in Added)
            {
                conn.Execute("INSERT INTO Emps (Name, Age) VALUES(@Name, @Age);",
                         new { Name = employee.Name, Age = employee.Age });
            }

            Discard();
        }
    }
}