using Microsoft.AspNetCore.Mvc;
using Cannabis.Infrastructure.Data.Context;
using Cannabis.Api.Errors;
using Microsoft.AspNetCore.Authorization;

namespace Cannabis.Api.Controllers;

public class BuggyController : BaseApiController
{
    private readonly StoreContext _context;

    public BuggyController(StoreContext contex) =>  _context = contex;
    
    [HttpGet("testauth")]
    [Authorize]
    public ActionResult<string> GetSecretText() => "Secret stuff";

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest() => BadRequest(new ApiResponse(400));

    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id) => Ok();

    [HttpGet("notfound")]
    public ActionResult GetNotFoundRequest()
    {
        var thing = _context.Products.Find(42);
        return thing == null ? NotFound(new ApiResponse(404)) : Ok();
    }

    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        var thing = _context.Products.Find(42);
        var thingToReturn = thing.ToString();
        return Ok();
    }
}
