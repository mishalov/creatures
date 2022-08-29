using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CreatureWars.Class;
using CreatureWars.Formulas;
using GameDatabase;

namespace CmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemPrototypeController : ControllerBase
{
    private readonly GameContext _gameContext;

    public ItemPrototypeController(GameContext _gameContext)
    {
        this._gameContext = _gameContext;
    }
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public Post(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    [HttpGet]
    public ActionResult<IEnumerable<ItemPrototype>> Index()
    {
        return this._gameContext.ItemPrototypes.ToArray();
    }

    // [HttpPost]
    // public async Task<ActionResult<IEnumerable<User>>> Get()
    // {
    //     return await db.Users.ToListAsync();
    // }
}
