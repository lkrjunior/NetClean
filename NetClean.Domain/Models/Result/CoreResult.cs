using System.Net;

namespace NetClean.Domain.Models.Result
{
    public sealed class CoreResult<TResponse>
        where TResponse : class
    {
        public HttpStatusCode StatusCode { get; private set; }
        public TResponse Data { get; private set; }
        public string ErrorTitle { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool HasError { get; private set; }

        private static CoreResult<TResponse> AsError(HttpStatusCode statusCode, string errorTitle, string errorMessage)
        {
            return new CoreResult<TResponse>()
            {
                StatusCode = statusCode,
                HasError = true,
                ErrorTitle = errorTitle,
                ErrorMessage = errorMessage
            };
        }

        public static CoreResult<TResponse> AsOk(TResponse responseData)
        {
            return new CoreResult<TResponse>()
            {
                StatusCode = HttpStatusCode.OK,
                HasError = false,
                Data = responseData
            };
        }

        public static CoreResult<TResponse> AsNotFound(string errorMessage)
        {
            return AsError(HttpStatusCode.NotFound, nameof(HttpStatusCode.NotFound), errorMessage);
        }

        public static CoreResult<TResponse> AsBadRequest(string errorTitle, string errorMessage)
        {
            return AsError(HttpStatusCode.BadRequest, errorTitle, errorMessage);
        }

        public static CoreResult<TResponse> AsBadRequest(string errorMessage)
        {
            return AsError(HttpStatusCode.BadRequest, nameof(HttpStatusCode.BadRequest), errorMessage);
        }

        public static CoreResult<TResponse> AsError(string errorMessage)
        {
            return AsError(HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError), errorMessage);
        }
    }
}