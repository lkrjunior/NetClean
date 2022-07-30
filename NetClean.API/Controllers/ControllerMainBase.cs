using System;
using Microsoft.AspNetCore.Mvc;
using NetClean.Domain.Models;
using NetClean.Domain.Models.Result;

namespace NetClean.API.Controllers
{
    public abstract class ControllerMainBase : ControllerBase
    {
        protected IActionResult AsActionResult<T>(CoreResult<T> coreResult) where T : class
        {
            return coreResult.CoreStatus switch
            {
                CoreStatus.Ok =>
                    Ok(coreResult.Data),
                CoreStatus.NotFound =>
                    Problem(coreResult.ErrorMessage, HttpContext.Request.Path, StatusCodes.Status404NotFound, coreResult.ErrorTitle),
                CoreStatus.BadRequest =>
                    Problem(coreResult.ErrorMessage, HttpContext.Request.Path, StatusCodes.Status400BadRequest, coreResult.ErrorTitle),
                CoreStatus.Error =>
                    Problem(coreResult.ErrorMessage, HttpContext.Request.Path, StatusCodes.Status500InternalServerError, coreResult.ErrorTitle),
                _ => throw new ArgumentException($"{nameof(coreResult.CoreStatus)} not found"),
            };
        }
    }
}

