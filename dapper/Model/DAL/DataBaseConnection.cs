using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Model.DAL;

public class DataBaseConnection
{
    private readonly string _connectionString;

    public DataBaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}

    