using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RewardsApi.exemple.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RewardsController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<string>> Get()
    {
        return Ok("RewardsApi data");
    }
}
