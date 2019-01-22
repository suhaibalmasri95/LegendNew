using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Financial;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.Customer_Contacts
{
    public class AddUpdateCustomerContacts
    {

        public async static Task<IDTO> AddUpdateMode(CustomerContact customerContact)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            if (customerContact.ID.HasValue)
            {
                oracleParams.Add(CustomerContactsSpParam.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerContact.ID ?? DBNull.Value);

                SPName = CustomerContactsSpName.CUSTOMER_CONTACT_UPDATE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerContactsSpParam.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerContactsSpName.CUSTOMER_CONTACT_INSERT;
                message = "Inserted Successfully";
            }
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerContact.CustomerID ?? DBNull.Value);

            oracleParams.Add(CustomerContactsSpParam.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.Name ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.Name2 ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_POHNE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.PhoneCode ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.Phone ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_MOBILE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.Mobile ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.Email ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)customerContact.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_LOC_INS_DEPT, OracleDbType.Int64, ParameterDirection.Input, (object)customerContact.LocCustomerDept ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerContact.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerContact.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerContactsSpParam.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerContact.ModificationDate ?? DBNull.Value);
       
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
