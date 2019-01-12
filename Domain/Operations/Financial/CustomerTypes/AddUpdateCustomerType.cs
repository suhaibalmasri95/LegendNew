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
    public class AddUpdateCustomerType
    {

        public async static Task<IDTO> AddUpdateMode(CustomerType customerType)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            if (customerType.ID.HasValue)
            {
                oracleParams.Add(CustomerTypeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerType.ID ?? DBNull.Value);

                SPName = CustomerTypesSpName.SP_UPADTE_CUSTOMER_TYPE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerTypeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerTypesSpName.SP_INSERT_CUSTOMER_TYPE;
                message = "Inserted Successfully";
            }

            oracleParams.Add(CustomerTypeSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerType.CustomerID ?? DBNull.Value);
            oracleParams.Add(CustomerTypeSpParams.PARAMETER_LOC_CUST_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)customerType.LocCustomerType ?? DBNull.Value);
            oracleParams.Add(CustomerTypeSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerType.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerTypeSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerType.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerTypeSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerType.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerTypeSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerType.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CustomerTypeSpParams.PARAMETER_FIN_GL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerType.FinGlID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
