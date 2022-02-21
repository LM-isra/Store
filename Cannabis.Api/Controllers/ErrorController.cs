using Microsoft.AspNetCore.Mvc;
using Cannabis.Api.Errors;

namespace Cannabis.Api.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseApiController
{
    public IActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
}
