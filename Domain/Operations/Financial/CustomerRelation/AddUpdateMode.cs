using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerRelation
{
   public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Entities.Financial.CustomerRelation customerRelation)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            if (customerRelation.ID.HasValue)
            {
                oracleParams.Add(CustomerRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerRelation.ID ?? DBNull.Value);

                SPName = CustomerRelationSpName.SP_UPADTE_CUSTOMER_RELATIONS;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerRelationSpName.SP_INSERT_CUSTOMER_RELATIONS;
                message = "Inserted Successfully";
            }
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerRelation.CustomerID ?? DBNull.Value);
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_FIN_CST_ID2, OracleDbType.Int64, ParameterDirection.Input, (object)customerRelation.CustomerID2 ?? DBNull.Value);
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_LOC_REL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)customerRelation.LocRelationType ?? DBNull.Value);
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerRelation.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerRelation.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerRelation.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerRelationSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerRelation.ModificationDate ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
