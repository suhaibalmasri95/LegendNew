﻿using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.SubBusiness
{
    public static class DBSubBusniesSetup
    {
        public async static Task<IDTO> AddUpdateMode(SubLineOfBusnies busnies)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (busnies.ID.HasValue)
            {
                oracleParams.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ID ?? DBNull.Value);
                oracleParams.Add(SubBusniesSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.CreationDate);
                oracleParams.Add(SubBusniesSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, "Admin");
                oracleParams.Add(SubBusniesSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, DateTime.Now);
                SPName = SubBusniesSPName.SP_UPADTE_SubBusnies;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                oracleParams.Add(SubBusniesSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, "Admin");
                oracleParams.Add(SubBusniesSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.CreationDate ?? DBNull.Value);
                SPName = SubBusniesSPName.SP_INSERT_SubBusnies;
                message = "Inserted Successfully";
            }

            oracleParams.Add(SubBusniesSpParams.PARAMETER_SUB_LOB, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.BasicLineOfBusniess ?? DBNull.Value, 500);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_ST_LOB_ID, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.LineOfBusniess ?? DBNull.Value, 500);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name ?? DBNull.Value, 500);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.Code ?? DBNull.Value);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_CREATED_BY, OracleDbType.Int64, ParameterDirection.Input, "Admin");
            oracleParams.Add(SubBusniesSpParams.PARAMETER_STATUS, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Status ?? DBNull.Value, 50);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.StatusDate ?? DBNull.Value);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_RINS_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ReinsType ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
