// using Dapper;
// using Microsoft.Data.Sqlite;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Model.DAL;
// using Model.Domain;
// using System.Data;
// using System.Data.SqlClient;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace Model;

// public class DapperRepository : EntityRepository<Employee>
// {
//     public DapperRepository(string connectionString)
//     {
//         _connectionString = connectionString;
//     }

//     public override IEnumerable<Employee> GetAll()
//     {
//         foreach (var employee in Added)
//         {
//             yield return employee;
//         }

//         using (var conn = new SqliteConnection(_connectionString))
//         {
//             conn.Open();
//             string cmdText = "SELECT Id, Name, Age FROM dbo.Emps";
//             if (Deleted.Count > 0)
//                 cmdText += string.Format("where Id NOT IN {{0}}", string.Join(",", DeletedIds));
//             var command = new SqliteCommand(cmdText, conn);
//             using (var reader = command.ExecuteReader())
//             {
//                 while (reader.Read())
//                 {
//                     var emp = new Employee
//                     {
//                         Id = (int)reader["Id"],
//                         Name = (string)reader["Name"],
//                         Age = (int)reader["Age"]
//                     };
//                     yield return emp;
//                 }
//             } 
//         }
//     }
//     public override string GetUpdateScript()
//     {
//         string script = string.Empty;
//         string delScriptTemplate = "DELETE FROM dbo.Emps WHERE Id IN ({0})";
//         string addScriptTemplate = "INSERT INTO [dbo].[Emps] ([Name])VALUES('{0}', [Age])VALUES('{0}')";
//         if (Deleted.Count > 0)
//             script += string.Format(delScriptTemplate, DeletedIds);
//         foreach (var employee in Added)
//         {
//             script += string.Format("\n" + addScriptTemplate, employee.Name);
//         }
//         return script;
//     }
// }