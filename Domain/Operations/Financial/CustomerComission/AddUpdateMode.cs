using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerComission
{
  public static  class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Entities.Financial.CustomerCommission customerCommission)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            if (customerCommission.ID.HasValue)
            {
                oracleParams.Add(CustomerCommissionSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.ID ?? DBNull.Value);

                SPName = CustomerCommissionSpName.SP_UPADTE_CUSTOMER_COMM;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerCommissionSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerCommissionSpName.SP_INSERT_CUSTOMER_COMM;
                message = "Inserted Successfully";
            }
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.CustomerID ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_LOC_CUST_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.LocCustomerType ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerCommission.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerCommission.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerCommission.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerCommission.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_COMM_PERC, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.ComissionPercentage ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_COMM_AMOUNT, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.CommissionAmount ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_COMM_AMOUNT_LC, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.CommissionAmount ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.ProductId ?? DBNull.Value);

            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.ProductDetailId ?? DBNull.Value);



            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.SubLineOfBusiness ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_DRT_CR, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.DrtCr ?? DBNull.Value);
            oracleParams.Add(CustomerCommissionSpParams.PARAMETER_LOC_COMM_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)customerCommission.LocCommissionType ?? DBNull.Value);



            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
