using Microsoft.AspNetCore.Http;

namespace E_Commerce.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponse(int status, string message = null)
        {
            StatusCode = status;
            ErrorMessage = message ?? GetDefaultMessageForStatusCode(status);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side",
                _ => null
            };
        }
    }
}
