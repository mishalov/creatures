using Microsoft.AspNetCore.Mvc;

namespace CmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemPrototypeController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public Post(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return await db.Users.ToListAsync();
    }
}
