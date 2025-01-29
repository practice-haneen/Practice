using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers;

[Route("api/first")]
[ApiController]
public class FirstController : ControllerBase
{
    [HttpGet]
    public string WriteName(string name)
    {
        return name;
    }
    
    [HttpGet("exception")]
    public IActionResult WriteException()
    {
        throw new InvalidOperationException("This is a test exception.");
    }
}
