using Common.Interfaces;
using Common.Operations;
using Domain.Operations.Organization.UserGroups;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Users
{
    public static class DBUserSetup
    {
        public async static Task<IDTO> AddUpdateMode(User user)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (user.ID.HasValue)
            {
                oracleParams.Add(UserSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)user.ID ?? DBNull.Value);
                SPName = UserSpName.SP_UPADTE_USER;
                message = "Updated Successfully";
                user.ModificationDate = DateTime.Now;
            }
            else { 
                oracleParams.Add(UserSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = UserSpName.SP_INSER_USER;
                message = "Inserted Successfully";
                user.CreationDate = DateTime.Now;
            }
            oracleParams.Add(UserSpParams.PARAMETER_USERNAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.UserName ?? DBNull.Value, 30);
            oracleParams.Add(UserSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.Name ?? DBNull.Value, 500);
            oracleParams.Add(UserSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(UserSpParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)user.EffectiveDate ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)user.ExpiryDate ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_LOCKUP_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)user.Status ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)user.StatusDate ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_PASSWORD, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.Password ?? DBNull.Value,1000);
            oracleParams.Add(UserSpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.Email ?? DBNull.Value, 30);
            oracleParams.Add(UserSpParams.PARAMETER_COMPANY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)user.CompanyID ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_NO_OF_LOGIN, OracleDbType.Int64, ParameterDirection.Input, (object)user.NoOfLogin ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_BIRTHDATE, OracleDbType.Date, ParameterDirection.Input, (object)user.BirthDate ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_PICTURE, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.Picture ?? DBNull.Value,500);
            oracleParams.Add(UserSpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)user.CountryID ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_MOBILE, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.Mobile ?? DBNull.Value,30);
            oracleParams.Add(UserSpParams.PARAMETER_LOCKUP_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)user.UserType ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.CreatedBy ?? DBNull.Value,30);
            oracleParams.Add(UserSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)user.CreationDate ?? DBNull.Value);
            oracleParams.Add(UserSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)user.ModifiedBy ?? DBNull.Value,30);
            oracleParams.Add(UserSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)user.ModificationDate ?? DBNull.Value);

       
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.message = message;
                long UserID = oracleParams.Get<long>(0);
                if(user.UserRelations.Count > 0)
                {
                    // Add Relations

                    foreach (var item in user.UserRelations)
                    {
                        await DBUserGroupSetup.AddUpdateMode(item);

                    }

                }
                    }
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
