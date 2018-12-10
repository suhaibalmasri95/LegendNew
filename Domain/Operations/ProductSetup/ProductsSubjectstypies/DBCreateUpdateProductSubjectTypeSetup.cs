using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductsSubjectstypies
{
    public static class DBCreateUpdateProductSubjectTypeSetup
    {
        public async static Task<IDTO> AddUpdate(ProductSubjectType Product)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (Product.ID.HasValue)
            {
                oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ID ?? DBNull.Value);
                SPName = ProductSubjectsTypiesSPName.SP_UPADTE_PRODUCT_SUBJECT_TYPE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductSubjectsTypiesSPName.SP_INSERT_PRODUCT_SUBJECT_TYPE;
                message = "Inserted Successfully";
            }
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_EXCESS_PERC, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ExcessPerc ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_EXCESS_MIN, OracleDbType.Int64, ParameterDirection.Input, (object)Product.MinExcess ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_EXCESS_MAX, OracleDbType.Int64, ParameterDirection.Input, (object)Product.MaxExcess ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_EXCESS_FROM, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ExcessFrom ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_SUBJECT_TYPE_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.SubjectTypeID ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_SUBJECT_TYPE_PARENT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.SubjectTypeParentID ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_LINE_OF_BUSSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)Product.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_SUB_LINE_OF_BUSSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)Product.SubLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.CreateBy ?? DBNull.Value, 20);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.ModifiedBy ?? DBNull.Value, 20);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.ModificationDate ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_PRODUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ProductID ?? DBNull.Value);
            oracleParams.Add(ProductSubjectsTypiesSPParams.PARAMETER_PRODUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ProductDetailsID ?? DBNull.Value);
           

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
