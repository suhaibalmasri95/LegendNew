using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Domain.Operations.Financial.Customers;
using Domain.Operations.Production.Attachments;
using Domain.Operations.Production.Categories;
using Domain.Operations.Production.Columns;
using Domain.Operations.Production.Risks;
using Domain.Operations.Production.Shares;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Documents
{
  public static class DBDocumentsSetup
    {
        public async static Task<IDTO> AddUpdateMode(Document document)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (document.ID.HasValue)
            {
                oracleParams.Add(DocumentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.ID ?? DBNull.Value);

                SPName = DocumentSpName.SP_UPADTE_DOCUMENT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(DocumentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = DocumentSpName.SP_INSERT_DOCUMENT;
                message = "Inserted Successfully";
            }

            
            oracleParams.Add(DocumentSpParams.PARAMETER_DOC_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)document.DocumentType ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_DCOUMENT_NO, OracleDbType.Int64, ParameterDirection.Input, (object)document.DocumentNo ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_TRN_SERIAL, OracleDbType.Int64, ParameterDirection.Input, (object)document.TrnSerial ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_UW_YEAR, OracleDbType.Int64, ParameterDirection.Input, (object)document.UwYear ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_DOC_SEGMENT, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.DocumentSegment ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_ISSUE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.IssueDate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.EffectiveDate  ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.ExpiryDate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_REF_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.ReferenceNo ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_DOC_SHARE, OracleDbType.Decimal, ParameterDirection.Input, (object)document.DocumentShare ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_EXRATE, OracleDbType.Decimal, ParameterDirection.Input, (object)document.Exrate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_ST_CUR_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.CurrencyCode ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_NOTES, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.Notes ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_NOTES2, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.Notes2 ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_ACC_FOR, OracleDbType.Int64, ParameterDirection.Input, (object)document.AccountedFor ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_IS_CLAIMED, OracleDbType.Int64, ParameterDirection.Input, (object)document.IsClaimed ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_IS_PRINTED, OracleDbType.Int64, ParameterDirection.Input, (object)document.IsPrinted ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_IS_REINSURED, OracleDbType.Int64, ParameterDirection.Input, (object)document.IsReinsured ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_IS_POSTED, OracleDbType.Int64, ParameterDirection.Input, (object)document.IsPosted ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_IS_CANCELLED, OracleDbType.Int64, ParameterDirection.Input, (object)document.IsCancelled ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_OPEN_COVER_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)document.OpenCoverType ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)document.Status ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.StatusDate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.CreatedBy ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.CreationDate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)document.ModifiedBy ?? DBNull.Value, 1000);
            oracleParams.Add(DocumentSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.ModificationDate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.UwDocId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_ST_PROD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.ProductId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_LOC_PYM_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.PaymentId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_LOC_BUST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.LocBustId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_LOC_ENDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.LocEndtId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_ST_COM_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.StComId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_ST_BRN_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.StBrnId ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_QUT_VALIDITY, OracleDbType.Int64, ParameterDirection.Input, (object)document.QutValidity ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_FYR_YEAR, OracleDbType.Int64, ParameterDirection.Input, (object)document.FyrYear ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_FINANCIAL_DATE, OracleDbType.Date, ParameterDirection.Input, (object)document.FinancialDate ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_CALC_BASES, OracleDbType.Int64, ParameterDirection.Input, (object)document.CalcBases ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_LOC_DIST_CHNALES, OracleDbType.Int64, ParameterDirection.Input, (object)document.LocDistChnales ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_NET_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)document.NetAmount ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_NET_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)document.NetAmountLc ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_LOADING_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)document.LoadingAmount ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_LOADING_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)document.LoadingAmountLc ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_DISCOUNT_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)document.DiscountAmount ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_DISCOUNT_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)document.DiscountAmountLc ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_CHARGES_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)document.ChargesAmount ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_CHARGES_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)document.ChargesAmountLc ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_COMM_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)document.CommAmount ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_COMM_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)document.CommAmountLc ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_GROSS_AMMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)document.GrossAmmount ?? DBNull.Value);
            oracleParams.Add(DocumentSpParams.PARAMETER_GROSS_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)document.GrossAmountLc ?? DBNull.Value);



            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.message = message;
                complate.ID = oracleParams.Get(0);

                if(!document.UpdateMode)
                {
                    Attachment atacchment = new Attachment();
                    atacchment.DocumentID = complate.ID;
                    atacchment.Level = document.DocumentType;
                    atacchment.CreatedBy = document.CreatedBy;
                    atacchment.CreationDate = document.CreationDate;
                    var attachmentResult = AutoAddAttachment.AutoAdd(atacchment);
                }

                if (document.NewCustomer.ID.HasValue)
                {
                    var customerResult = AddUpdateCustomer.AddUpdateMode(document.NewCustomer, false);
                    Share share = new Share();
                    share.DocumentID = complate.ID;
                    share.SharePercent = 100;
                    share.Amount = 0;
                    share.AmountLC = 0;
                    share.StSubLOB = null;
                    share.StLOB = null;
                    share.LocShareType = 1;
                    share.CustomerId = document.NewCustomer.ID;
                    share.CreatedBy = document.CreatedBy;
                    share.CreationDate = document.CreationDate;
                    var result = DBSharesSetup.AddUpdateMode(share);

                    Share share2 = new Share();
                    share2.DocumentID = complate.ID;
                    share2.SharePercent = 100;
                    share2.Amount = 0;
                    share2.AmountLC = 0;
                    share2.StSubLOB = null;
                    share2.StLOB = null;
                    share2.LocShareType = 2;
                    share2.CustomerId = document.NewCustomer.ID;
                    share2.CreatedBy = document.CreatedBy;
                    share2.CreationDate = document.CreationDate;
                    var result2 = DBSharesSetup.AddUpdateMode(share2);
                    // check if has bene
                    foreach (var item in document.share.customer)
                    {
                        Share customerShare = new Share();
                        customerShare.DocumentID = complate.ID;
                        customerShare.SharePercent = 100;
                        customerShare.Amount = 0;
                        customerShare.AmountLC = 0;
                        customerShare.Percent = item.Commision;
                        customerShare.StSubLOB = null;
                        customerShare.StLOB = null;
                        customerShare.LocShareType = item.shareType;
                        customerShare.CustomerId = item.CustomerID;
                        var shhareResult = DBSharesSetup.AddUpdateMode(customerShare);



                    }
                }
                else
                {
                    var customerResult = await AddUpdateCustomer.AddUpdateMode(document.NewCustomer, true);
                    var CustomerID = ((ComplateOperation<int>)customerResult).ID.Value;
              
                    foreach (var item in document.share.customer)
                    {
                        Share customerShare = new Share();
                        customerShare.DocumentID = complate.ID;
                        customerShare.SharePercent = 100;
                        customerShare.Percent = item.Commision;
                        customerShare.Amount = 0;
                        customerShare.AmountLC = 0;
                        customerShare.StSubLOB = null;
                        customerShare.StLOB = null;
                        customerShare.LocShareType = item.shareType;
                        customerShare.CustomerId = item.CustomerID;
                        var shhareResult = DBSharesSetup.AddUpdateMode(customerShare);



                    }
                }
               
                foreach (var item2 in document.DynamicCategories)
                {

                    // map to category

                    if (item2.IsMulitRecords > 0)
                    {
                        foreach (var col in item2.Result)
                        {
                            if(document.UpdateMode) {

                                foreach (var c in col)
                                {
                                  
                                    var result = AddUpdateCoulmns.AddUpdateMode(c);
                                }
                            }
                            else { 
                            var category = AddUpdateCategory.MapToCategory(item2 , null , complate.ID);
                            var categoryID = await AddUpdateCategory.AddUpdateMode(category);
                            var id = ((ComplateOperation<int>)categoryID).ID.Value;
                            foreach (var c in col)
                            {
                               
                                c.UnderWritingColCatID = id;
                                c.UnderWritingRiskID = category.RiskID;
                                c.UnderWritingDocID = category.DocumentID;
                                c.LineOfBuisness = category.LineOfBusiness;
                                c.SubLineOfBuisness = category.SubLineOfBusiness;
                                c.ProductCategoryID = category.ProductCategoryID;
                                var result = AddUpdateCoulmns.AddUpdateMode(c);
                            }
                            }
                        }
                    }
                    else
                    {
                        var category = AddUpdateCategory.MapToCategory(item2, null, complate.ID);
                        var categoryID = await AddUpdateCategory.AddUpdateMode(category);
                        var id = ((ComplateOperation<int>)categoryID).ID.Value;
                        foreach (var col in item2.ResultList)
                        {
                            col.ID = null;
                            col.UnderWritingColCatID = id;
                            col.UnderWritingRiskID = category.RiskID;
                            col.UnderWritingDocID = category.DocumentID;
                            col.LineOfBuisness = category.LineOfBusiness;
                            col.SubLineOfBuisness = category.SubLineOfBusiness;
                            var result = AddUpdateCoulmns.AddUpdateMode(col);
                        }


                    }



                }
            }
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
