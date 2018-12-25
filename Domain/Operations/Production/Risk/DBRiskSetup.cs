using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Risks
{
    class DBRiskSetup
    {
        public async static Task<IDTO> AddUpdateMode(Risk risk)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (risk.ID.HasValue)
            {
                oracleParams.Add(RiskSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.ID ?? DBNull.Value);

                SPName = RiskSpName.SP_UPADTE_RISK;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(RiskSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = RiskSpName.SP_INSERT_RISK;
                message = "Inserted Successfully";
            }

            oracleParams.Add(RiskSpParams.PARAMETER_SERIAL, OracleDbType.Int64, ParameterDirection.Input, (object)risk.Serial ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)risk.Name ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_DESCRIPTION, OracleDbType.Varchar2, ParameterDirection.Input, (object)risk.Description ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)risk.EffectiveDate ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)risk.ExpiryDate ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_OUR_SHARE, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.OurShare ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_MIN_EXCESS_AMT, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.MinExcessAmount ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_MAX_EXCESS_AMT, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.MaxExcessAmount ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_REF_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)risk.RefNo ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)risk.StLOB ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)risk.StSubLOB ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.UwDocumentID ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_SUMINSURED, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.Suminsured ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_SUMINSURED_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.SuminsuredLC ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_NET_PREMIUM, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.NetPremium ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_NET_PREMIUM_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.NetPremiumLc ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_GROSS_PREMIUM, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.GrossPremium ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_GROSS_PREMIUM_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)risk.GrossPremiumLc ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_ST_PRD_SBT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.ProductSubjectTypeID ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_ST_SBT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.SubjectTypeID ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_ST_PROD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.ProductID ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.ProductDetailID ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_UW_MBR_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.MemberID ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)risk.CreatedBy ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)risk.CreationDate ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)risk.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)risk.ModificationDate ?? DBNull.Value);
            oracleParams.Add(RiskSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)risk.UwRiskID ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.message = message;
                complate.ID = oracleParams.Get(0);
            }
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
