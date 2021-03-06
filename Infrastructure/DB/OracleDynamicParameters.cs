﻿using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.DB
{
    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null)
        {
            OracleParameter oracleParameter;
            if (size.HasValue)
            {
                oracleParameter = new OracleParameter(name, oracleDbType, size.Value, value, direction);

            }
            else
            {
                oracleParameter = new OracleParameter(name, oracleDbType, value, direction);

            }

            oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleDbType dbType, object val, ParameterDirection dir)
        {

        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        {
            var oracleParameter = new OracleParameter(name, oracleDbType, direction);
            oracleParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {

            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as OracleCommand;

            oracleCommand.InitialLONGFetchSize = 0;
            oracleCommand.BindByName = false;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }

        public Int64 Get(int index)
        {
            string val = oracleParameters[index].Value.ToString();
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            return Int64.Parse(val);
        }
    }
}
