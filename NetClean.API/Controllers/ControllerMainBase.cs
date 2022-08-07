using Microsoft.AspNetCore.Mvc;
using NetClean.Domain.Models.Result;

namespace NetClean.API.Controllers
{
    public abstract class ControllerMainBase : ControllerBase
    {
        protected IActionResult AsActionResult<T>(CoreResult<T> coreResult) where T : class
        {
            if (coreResult.HasError)
            {
                var statusCode = (int)coreResult.StatusCode;

                return Problem(coreResult.ErrorMessage, HttpContext.Request.Path, statusCode, coreResult.ErrorTitle);
            }

            return new ObjectResult(coreResult.Data)
            {
                StatusCode = (int) coreResult.StatusCode
            };
        }
    }
}