using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.PricingDetails
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(PricingDetail pricingDetail)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (pricingDetail.ID.HasValue)
            {
                oracleParams.Add(PricingDetailsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.ID ?? DBNull.Value);

                SPName = PricingDetailsSpName.SP_UPADTE_PRICING_DETAIL;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(PricingDetailsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = PricingDetailsSpName.SP_INSERT_PRICING_DETAIL;
                message = "Inserted Successfully";
            }


            oracleParams.Add(PricingDetailsSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)pricingDetail.CreatedBy ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricingDetail.CreationDate ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)pricingDetail.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricingDetail.ModificationDate ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.Status ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricingDetail.StatusDate ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricingDetail.EffectiveDate ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricingDetail.ExpiryDate ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.ProductID ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.ProductDetailID ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.SubLineOfBusiness ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_IS_FACTOR, OracleDbType.Int16, ParameterDirection.Input, (object)pricingDetail.IsFactor ?? DBNull.Value);
            oracleParams.Add(PricingDetailsSpParams.PARAMETER_ST_PRD_PRIC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.PricingID ?? DBNull.Value);

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
