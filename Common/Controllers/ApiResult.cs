using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Controllers
{
    public class ApiResult<DataType> : IApiResult
    {

        public ApiStatus Status;
        public DataType Data;

        public enum ApiStatus
        {
            Failed,
            Success
        }
    }
}
