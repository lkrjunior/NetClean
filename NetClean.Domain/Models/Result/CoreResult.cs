using System;

namespace NetClean.Domain.Models.Result
{
    public sealed class CoreResult<TResponse>
        where TResponse : class
    {
        public CoreStatus CoreStatus { get; private set; }
        public TResponse Data { get; private set; }
        public string ErrorTitle { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool HasError { get; private set; }

        private static CoreResult<TResponse> AsError(CoreStatus coreStatus, string errorTitle, string errorMessage)
        {
            return new CoreResult<TResponse>()
            {
                CoreStatus = coreStatus,
                HasError = true,
                ErrorTitle = errorTitle,
                ErrorMessage = errorMessage
            };
        }

        public static CoreResult<TResponse> AsOk(TResponse responseData)
        {
            return new CoreResult<TResponse>()
            {
                CoreStatus = CoreStatus.Ok,
                HasError = false,
                Data = responseData
            };
        }

        public static CoreResult<TResponse> AsNotFound(string errorMessage)
        {
            return AsError(CoreStatus.NotFound, nameof(CoreStatus.NotFound), errorMessage);
        }

        public static CoreResult<TResponse> AsBadRequest(string errorTitle, string errorMessage)
        {
            return AsError(CoreStatus.BadRequest, errorTitle, errorMessage);
        }

        public static CoreResult<TResponse> AsBadRequest(string errorMessage)
        {
            return AsError(CoreStatus.BadRequest, nameof(CoreStatus.BadRequest), errorMessage);
        }

        public static CoreResult<TResponse> AsError(string errorMessage)
        {
            return AsError(CoreStatus.Error, nameof(CoreStatus.Error), errorMessage);
        }
    }
}