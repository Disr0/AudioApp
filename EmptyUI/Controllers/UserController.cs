using AudioApp.Logic.Contracts;
using AudioApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AudioApp.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetList()
    {
        return Ok(_userService.GetList());
    }
}