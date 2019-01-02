using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductDynamic;
using Domain.Entities.Production;
using Domain.Operations.Production.Columns;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Categories
{
   public static class AddUpdateCategory 
    {
        public async static Task<IDTO> AddUpdateMode(Entities.Production.Category category)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (category.ID.HasValue)
            {
                oracleParams.Add(CategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.ID ?? DBNull.Value);
                SPName = CategorySpName.SP_UPADTE_CATEGORY;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CategorySpName.SP_INSERT_CATEGORY;
                message = "Inserted Successfully";
            }

            oracleParams.Add(CategorySpParams.PARAMETER_PRODUCT_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.ProductCategoryID ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.Lable ?? DBNull.Value, 100);
            oracleParams.Add(CategorySpParams.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.Lable2 ?? DBNull.Value , 100);
            oracleParams.Add(CategorySpParams.PARAMETER_CAT_ORDER, OracleDbType.Int64, ParameterDirection.Input, (object)category.CategoryOrder ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.RiskID ?? DBNull.Value, 50);
            oracleParams.Add(CategorySpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.DocumentID ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)category.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)category.SubLineOfBusiness ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_UW_MBR_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.MemberID ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1) { 
                complate.message = message;
                complate.ID = oracleParams.Get(0);
              
            
            }
            else { 
                complate.message = "Operation Failed";
            }

            return complate;
        }


        public static Category MapToCategory( ProductDynmicCategory prodCategory , long? riskID , long? DocumentID)
        {
            Category category = new Category
            {
                Lable = prodCategory.Lable,
                Lable2 = prodCategory.Lable2,
                RiskID = riskID,
                DocumentID = DocumentID,
                CategoryOrder = prodCategory.OrderID,
                LineOfBusiness = prodCategory.LineOfBuisness,
                SubLineOfBusiness = prodCategory.SubLineOfBuisness,
                MemberID = null,
                ProductCategoryID = prodCategory.ID,
                ResultList = prodCategory.ResultList,
                Result = prodCategory.Result,
                IsMulti = prodCategory.IsMulitRecords

            };

            return category;
        }



     
    }
}
