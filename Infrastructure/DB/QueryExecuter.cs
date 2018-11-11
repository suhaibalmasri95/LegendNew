using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public static class QueryExecuter
    {
        public static async Task<List<DTO>> ExecuteQueryAsync<DTO>(string SPName, OracleDynamicParameters Params) where DTO : class, new()
        {
            List<DTO> result = null;
            IDataReader dataReader = null;
            try
            {
                var connection = new DbConnection().GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (connection.State == ConnectionState.Open)
                {
                    dataReader = await SqlMapper.ExecuteReaderAsync(connection, SPName, param: Params, commandType: CommandType.StoredProcedure);
                    result = dataReader.Map<DTO>();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
