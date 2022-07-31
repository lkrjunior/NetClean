using System;
using Microsoft.AspNetCore.Mvc;
using NetClean.Domain.Models.Common;
using NetClean.Domain.Models.Result;

namespace NetClean.API.Controllers
{
    public abstract class ControllerMainBase : ControllerBase
    {
        private ObjectResult Problem<T>(int httpStatusCode, CoreResult<T> coreResult) where T : class
        {
            return Problem(coreResult.ErrorMessage, HttpContext.Request.Path, httpStatusCode, coreResult.ErrorTitle);
        }

        protected IActionResult AsActionResult<T>(CoreResult<T> coreResult) where T : class
        {
            return coreResult.CoreStatus switch
            {
                CoreStatus.Ok =>
                    Ok(coreResult.Data),
                CoreStatus.NotFound =>
                    Problem(StatusCodes.Status404NotFound, coreResult),
                CoreStatus.BadRequest =>
                    Problem(StatusCodes.Status400BadRequest, coreResult),
                CoreStatus.Error =>
                    Problem(StatusCodes.Status500InternalServerError, coreResult),
                _ => throw new ArgumentException($"{nameof(coreResult.CoreStatus)} not found"),
            };
        }
    }
}

