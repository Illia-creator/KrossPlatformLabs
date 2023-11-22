using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Api.Controllers;


[ApiController]
[Authorize("ApiScope")]
[Route("[controller]")]
public class AppController : ControllerBase
{
    [HttpGet]
    public string StartApi()
        => "start";
}

