﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public static class NonQueryExecuter
    {
        public static async Task<int> ExecuteNonQueryAsync(string SPName, OracleDynamicParameters Params)
        {
            int result = 0;
            var connection = new DbConnection().GetConnection();
            try
            {
    
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (connection.State == ConnectionState.Open)
                {
                    result = await SqlMapper.ExecuteAsync(connection, SPName, param: Params, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }

            return result;
        }
        public static async Task<int> ExecuteNonQueryAsync(string sql)
        {

            int result = 0;
            var connection = new DbConnection().GetConnection();
            try
            {
               
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (connection.State == ConnectionState.Open)
                {
                    result = await SqlMapper.ExecuteAsync(connection, sql);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }

            return result;
        }
    }
}
