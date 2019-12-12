using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SelfPay.Controllers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public ApiResponse()
        {

        }

        public ApiResponse(HttpStatusCode statusCode, string errorMessage = null, object result = null)
        {
            StatusCode = Convert.ToInt32(statusCode);
            Message = errorMessage;
            Result = result;
        }
    }
}