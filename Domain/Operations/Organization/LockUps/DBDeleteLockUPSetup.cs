﻿using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.LockUps
{
    public class DBDeleteLockUpSetup
    {
        public async static Task<IDTO> DeleteLockUpAsync(Lockup lockup)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(LockUpSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(LockUpSPName.SP_DELETE_LOCKUPS, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }

        public async static Task<IDTO> DeleteLockupsAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Lockup), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
    }
