using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.AdoNet
{
    public abstract class DbRepository
    {
        protected readonly string _connectionString;

        public DbRepository(AdoNetOptions options)
        {
            _connectionString = options.ConnectionString;
        }

        protected SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }
    }
}