﻿using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductsDetails
{
   public static class DBProductDetailsDeletionSetup
    {
        public async static Task<IDTO> DeleteProductDetailsAsync(ProductDetails product)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(ProductDetailsSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)product.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductDetailsSPName.SP_DELETE_PRODUCT_DETAILS, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

        public async static Task<IDTO> DeleteProductDetailsAsync(long[] IDs)
        {
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(ProductDetails), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
