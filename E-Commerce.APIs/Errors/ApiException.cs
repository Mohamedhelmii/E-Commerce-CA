using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce.APIs.Errors
{
    public class ApiException : ApiResponse
    {
        private string Details { get; set; }
        public ApiException(int statusCode, string message = null, string details = null)
        : base(statusCode, message)
        {
            Details = details;  
        }
    }
    #region Description
        // Added ApiException to extend ApiResponse with error details(StackTrace).
        // Created ExceptionMiddleware to catch all unhandled exceptions globally.
        // Configured the middleware to return consistent JSON responses based on the environment (Dev vs Prod).
    #endregion
}
