using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.DB
{
    public class DbConnection
    {
        private readonly IDbConnection connection;
        public DbConnection()
        {
            var connectionString = new AppConfiguration().SqlDataConnection;
            connection = new OracleConnection(connectionString);
        }
        public IDbConnection GetConnection()
        {
            return connection;

        }
    }
}
