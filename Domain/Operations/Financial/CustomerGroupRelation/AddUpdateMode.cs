using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerGroupRelation
{
  public static  class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Entities.Financial.CustomerGroupRelation customerGroupRelation)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            if (customerGroupRelation.ID.HasValue)
            {
                oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.ID ?? DBNull.Value);

                SPName = CustomerGrRelationSpName.SP_UPADTE_CUSTOMER_GROUP_RELATIONS;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerGrRelationSpName.SP_INSERT_CUSTOMER_GROUP_RELATIONS;
                message = "Inserted Successfully";
            }
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerGroupRelation.Name ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerGroupRelation.Name2 ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerGroupRelation.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerGroupRelation.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerGroupRelation.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerGroupRelation.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_ST_PARTD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.ProductDetailId ?? DBNull.Value);

            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_LOC_UNITT, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.LocUnit ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_PRICE_AMOUNT, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.PriceAmount ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_FREQ, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.Freq ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_REF_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerGroupRelation.ReferenceNo ?? DBNull.Value);
            oracleParams.Add(CustomerGrRelationSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.CustomerID ?? DBNull.Value);
     

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
