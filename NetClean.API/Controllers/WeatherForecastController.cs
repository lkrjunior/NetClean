using Microsoft.AspNetCore.Mvc;
using NetClean.Domain.Models.Result;

namespace NetClean.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerMainBase
{ 
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Get")]
    public IActionResult Get()
    {
        var result = CoreResult<string>.AsOk("Ok");

        return AsActionResult(result);
    }
}

