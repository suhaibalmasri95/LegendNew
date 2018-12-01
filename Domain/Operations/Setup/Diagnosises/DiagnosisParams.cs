using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Operations.Setup.Diagnosises
{
    public class DiagnosisParams
    {
        public static readonly string PARAMETER_ID = "IN_ID";
        public static readonly string PARAMETER_NAME = "IN_NAME";
        public static readonly string PARAMETER_NAME2 = "IN_NAME2";
        public static readonly string PARAMETER_CODE = "IN_CODE";
        public static readonly string PARAMETER_LOC_CODING_SYSTEM = "IN_ST_MED_SERVICES.LOC_CODING_SYSTEM";
        public static readonly string PARAMETER_LOC_SERVICE_TYPE = "IN_ST_MED_SERVICES.LOC_SERVICE_TYPE";
        public static readonly string PARAMETER_GENDER = "IN_ST_MED_SERVICES.GENDER";
        public static readonly string PARAMETER_AGE_FROM = "IN_ST_MED_SERVICES.AGE_FROM";
        public static readonly string PARAMETER_AGE_TO = "IN_ST_MED_SERVICES.AGE_TO";
        public static readonly string PARAMETER_FREQUENCY = "IN_ST_MED_SERVICES.FREQUENCY";
        public static readonly string PARAMETER_FREQUENCYUNIT = "IN_ST_MED_SERVICES.UNIT";
        public static readonly string PARAMETER_IS_CHRONIC= "IN_ST_MED_SERVICES.IS_CHRONIC";
        public static readonly string PARAMETER_IS_ICD_SERV_BEN = "IN_ST_MED_SERVICES.IS_ICD_SERV_BEN";
        public static readonly string PARAMETER_ST_ICD_SVC_ID = "IN_ST_MED_SERVICES.ST_ICD_SVC_ID";
        public const string PARAMETER_LANG_ID = "IN_LANG";
        public const string PARAMETER_REF_SELECT = "IN_REF_SELECT";
    }
}
