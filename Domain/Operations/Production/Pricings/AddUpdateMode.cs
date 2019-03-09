using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Pricings
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Pricing pricing)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (pricing.ID.HasValue)
            {
                oracleParams.Add(PricingSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricing.ID ?? DBNull.Value);

                SPName = PricingSpName.SP_UPADTE_PRICING;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(PricingSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = PricingSpName.SP_INSERT_PRICING;
                message = "Inserted Successfully";
            }


            oracleParams.Add(PricingSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)pricing.Name ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)pricing.Name2 ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)pricing.CreatedBy ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricing.CreationDate ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)pricing.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricing.ModificationDate ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)pricing.Status ?? DBNull.Value);

            oracleParams.Add(PricingSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricing.StatusDate ?? DBNull.Value, 1000);
            oracleParams.Add(PricingSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricing.ProductID ?? DBNull.Value);
            oracleParams.Add(PricingSpParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricing.EffectiveDate ?? DBNull.Value, 1000);
            oracleParams.Add(PricingSpParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)pricing.ExpiryDate ?? DBNull.Value);

            oracleParams.Add(PricingSpParams.PARAMETER_LOC_PRICE_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)pricing.PricingType ?? DBNull.Value);

            oracleParams.Add(PricingSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricing.CustomerID ?? DBNull.Value);




            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
          
                complate.ID = oracleParams.Get(0);
                complate.message = message;
            }

            else
            {
                complate.message = message;
            }

            return complate;
        }
    }
}

