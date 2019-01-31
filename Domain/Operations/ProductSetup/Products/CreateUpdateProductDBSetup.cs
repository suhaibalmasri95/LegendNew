using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.Products
{
    public static class CreateUpdateProductDBSetup
    {
        public async static Task<IDTO> AddUpdate(Product Product)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (Product.ID.HasValue)
            {
                oracleParams.Add(ProductSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ID ?? DBNull.Value);
                SPName = ProductSPName.SP_UPADTE_PRODUCT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductSPName.SP_INSERT_PRODUCT;
                message = "Inserted Successfully";
            }
            oracleParams.Add(ProductSPParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.Name ?? DBNull.Value, 1000);
            oracleParams.Add(ProductSPParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(ProductSPParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)Product.Status ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_LOGO, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.Logo ?? DBNull.Value, 1000);
            oracleParams.Add(ProductSPParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.Code ?? DBNull.Value, 30);
            oracleParams.Add(ProductSPParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.EffectiveDate ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.ExpiryDate ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.CreateBy ?? DBNull.Value, 50);
            oracleParams.Add(ProductSPParams.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.ModifiedBy ?? DBNull.Value, 50);
            oracleParams.Add(ProductSPParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.ModificationDate ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_LOCK_INDV_GROUPE, OracleDbType.Int16, ParameterDirection.Input, (object)Product.LockIndvGroup ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_COMPANY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.CompanyID ?? DBNull.Value);
            oracleParams.Add(ProductSPParams.PARAMETER_FIN_CUSTOMER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.FCustomerID ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.ID = oracleParams.Get(0);
                complate.message = message;
            }
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
