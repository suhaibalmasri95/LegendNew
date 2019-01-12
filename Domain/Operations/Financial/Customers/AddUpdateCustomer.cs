using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.CustomerTypes;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.Customers
{
    public static class AddUpdateCustomer
    {
        public async static Task<IDTO> AddUpdateMode(Customer customer, bool insertCustomerType)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();


            if (customer.ID.HasValue)
            {
                oracleParams.Add(CustomerSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customer.ID ?? DBNull.Value);

                SPName = CustomerSpName.SP_UPADTE_CUSTOMER;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerSpName.SP_INSERT_CUSTOMER;
                message = "Inserted Successfully";
            }

            oracleParams.Add(CustomerSpParams.PARAMETER_CUSTOMER_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.CustomerNo ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOC_TITLE, OracleDbType.Int64, ParameterDirection.Input, (object)customer.LockUpTitle ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Name ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_IND_COMP, OracleDbType.Int64, ParameterDirection.Input, (object)customer.IndOrComp ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_COMM_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.CommName ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_POHNE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.PhoneCode ?? DBNull.Value, 100);
            oracleParams.Add(CustomerSpParams.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Phone ?? DBNull.Value, 30);
            oracleParams.Add(CustomerSpParams.PARAMETER_MOBILE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Mobile ?? DBNull.Value, 30);
            oracleParams.Add(CustomerSpParams.PARAMETER_FAX, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Fax ?? DBNull.Value, 30);
            oracleParams.Add(CustomerSpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Email ?? DBNull.Value, 100);
            oracleParams.Add(CustomerSpParams.PARAMETER_WEBSITE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Website ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Address ?? DBNull.Value, 4000);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOC_LANGUAGE, OracleDbType.Int64, ParameterDirection.Input, (object)customer.LockUpLanguage ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOC_SECOTOR, OracleDbType.Int64, ParameterDirection.Input, (object)customer.LockUpSecotor ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_ST_CTY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customer.CityID ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_START_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.StatusDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOC_GENDERE, OracleDbType.Int64, ParameterDirection.Input, (object)customer.LockUpGender ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_BIRTH_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.BirthDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_REF_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.ReferenceNo ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_REF_EFF_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.RefEffectiveDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_REF_EXP_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.RefExpiryDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOC_TAX_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)customer.LockUpTaxType ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_TAX_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.TaxNo ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_START_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.StartDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_IBAN, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Iban ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_ST_BNK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customer.BankID ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_ST_BNKB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customer.BankBranchID ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)customer.Status ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_STATUS_NOTES, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.StatusNotes ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customer.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_ST_COM_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customer.CompanyID ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_ST_CUR_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.CurrencyCode ?? DBNull.Value, 30);

            oracleParams.Add(CustomerSpParams.PARAMETER_ST_CNT_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)customer.CountryCode ?? DBNull.Value);

            oracleParams.Add(CustomerSpParams.PARAMETER_ST_ARA_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customer.AreaID ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_POBOX, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.PoBox ?? DBNull.Value, 30);

            oracleParams.Add(CustomerSpParams.PARAMETER_POSTAL_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.PostalCode ?? DBNull.Value, 30);
            oracleParams.Add(CustomerSpParams.PARAMETER_NATIONALITY, OracleDbType.Int64, ParameterDirection.Input, (object)customer.Nationality ?? DBNull.Value);

            oracleParams.Add(CustomerSpParams.PARAMETER_IS_VIP, OracleDbType.Int16, ParameterDirection.Input, (object)customer.IsVip ?? DBNull.Value);
            oracleParams.Add(CustomerSpParams.PARAMETER_X_COORDINATES, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.XCoordinates ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_Y_COORDINATES, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.YCoordinates ?? DBNull.Value, 1000);
            oracleParams.Add(CustomerSpParams.PARAMETER_LOGO, OracleDbType.Varchar2, ParameterDirection.Input, (object)customer.Logo ?? DBNull.Value, 1000);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.ID = oracleParams.Get(0);
                if (insertCustomerType)
                {
                   
                    CustomerType policyHolder = new CustomerType();
                    policyHolder.CustomerID = complate.ID;
                    policyHolder.LocCustomerType = 1;
                    policyHolder.CreatedBy = customer.CreatedBy;
                    policyHolder.CreationDate = customer.CreationDate;
                    // insert customer as policy holder 
                    var policyHolderResult = AddUpdateCustomerType.AddUpdateMode(policyHolder);
                    CustomerType ben = new CustomerType();
                    ben.CustomerID = complate.ID;
                    ben.LocCustomerType = 2;
                    ben.CreatedBy = customer.CreatedBy;
                    ben.CreationDate = customer.CreationDate;
                    // insert customer as policy holder 
                    var benResult = AddUpdateCustomerType.AddUpdateMode(ben);
                    complate.message = message;
                    // insert customer as benef
                }
                else
                    complate.message = message;
              


            }
            else
            {
                complate.message = "Operation Failed";
            }

            return complate;
        }

    }
}
