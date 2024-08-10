﻿using System.Runtime.CompilerServices;
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
        _connectionString = new DataBaseConnection("/Users/Anna/Desktop/C\#/Repos-vscode/C-/dapper/ConsoleApp1/Emps.db;");
        _emps = new DapperRepository(_connectionString);


    public IRepository<Employee> Emps
    {
        get { return _emps; }
    }

    public bool SaveChanges()
    {
        try
        {
            using (var conn = _connectionString.GetConnection())
            {
                conn.Open();
                string cmdText = _emps.GetUpdateScript();
                Console.WriteLine("Generated SQL Command: " + cmdText);
                using (var command = new SqliteCommand(cmdText, conn)) // Замените SqliteCommand на SqlCommand, если используете SQL Server
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}"); // Логируем количество затронутых строк
                }
            }
            Discard();
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
