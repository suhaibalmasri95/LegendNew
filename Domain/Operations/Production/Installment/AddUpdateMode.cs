using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Installments
{
   public static class AddUpdateMode
    {
        public async static Task<IDTO>  AddUpdate(Installment installment)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
       
            if (installment.ID.HasValue)
            {
                oracleParams.Add(InstallmetSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)installment.ID ?? DBNull.Value);

                SPName = InstallmentSpName.SP_UPADTE_INSTALLMENT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(InstallmetSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = InstallmentSpName.SP_INSERT_INSTALLMENT;
                message = "Inserted Successfully";
            }


            oracleParams.Add(InstallmetSpParams.PARAMETER_DUE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)installment.DueDate ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_GROSS_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)installment.GrossAmount ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_GROSS_AMOUNT_LC, OracleDbType.Double, ParameterDirection.Input, (object)installment.GrossAmountLc ?? DBNull.Value);

            oracleParams.Add(InstallmetSpParams.PARAMETER_NET_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)installment.NetAmount ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_NET_AMOUNT_LC, OracleDbType.Double, ParameterDirection.Input, (object)installment.NetAmountLc    ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_INST_FEES, OracleDbType.Double, ParameterDirection.Input, (object)installment.FeesAmount ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_INST_FEES_LC, OracleDbType.Double, ParameterDirection.Input, (object)installment.FeesAmountLC ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_EXRATE, OracleDbType.Double, ParameterDirection.Input, (object)installment.Exrate ?? DBNull.Value);

            oracleParams.Add(InstallmetSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)installment.CreatedBy ?? DBNull.Value, 1000);
            oracleParams.Add(InstallmetSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)installment.CreationDate ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)installment.ModifiedBy ?? DBNull.Value, 1000);
            oracleParams.Add(InstallmetSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)installment.ModificationDate ?? DBNull.Value);

            oracleParams.Add(InstallmetSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)installment.DocumentID ?? DBNull.Value);

            oracleParams.Add(InstallmetSpParams.PARAMETER_INST_COMM, OracleDbType.Decimal, ParameterDirection.Input, (object)installment.CommissionAmount ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_INST_COMM_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)installment.CommissionAmountLc ?? DBNull.Value);
            oracleParams.Add(InstallmetSpParams.PARAMETER_INS_PERCENT, OracleDbType.Decimal, ParameterDirection.Input, (object)installment.Percent ?? DBNull.Value);




            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.message = "Operation Success";
            }
           
            else
            {
                complate.message = "Operation Failed";
            }

            return complate;
        }
            }
}
