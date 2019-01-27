using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Financial;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerTypes
{
  public static  class DeleteMode { 
    public async static Task<IDTO> DeleteCustomerType(CustomerType customerType)
    {
        OracleDynamicParameters oracleParams = new OracleDynamicParameters();
        ComplateOperation<int> complate = new ComplateOperation<int>();
        var dyParam = new OracleDynamicParameters();
        dyParam.Add(CustomerTypeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerType.ID ?? DBNull.Value);
        if (await NonQueryExecuter.ExecuteNonQueryAsync(CustomerTypesSpName.SP_DELETE_CUSTOMER_TYPE, dyParam) == -1)
            complate.message = "Operation Successed";
        else
            complate.message = "Operation Failed";
        return complate;
    }

    public async static Task<IDTO> DeleteCustomerTypes(long[] IDs)
    {

        ComplateOperation<int> complate = new ComplateOperation<int>();

        if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(CustomerType), IDs)) == -1)
            complate.message = "Operation Successed";
        else
            complate.message = "Operation Failed";

        return complate;
    }
}
}
