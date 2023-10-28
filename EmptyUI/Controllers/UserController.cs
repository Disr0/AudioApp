using AudioApp.Logic.Contracts;
using AudioApp.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
    public ActionResult<IEnumerable<UserVm>> GetList()
    {
        return Ok(_userService.GetList().Select(_ => new UserVm
        {
            Id = _.Id,
            Name = _.Name,
            Age = _.Age,
            LastName = _.LastName
        }));
    }

    [HttpGet]
    public ActionResult<UserVm> Get(int id)
    {
        var res = _userService.Get(id);
        if (res == null)
            return NotFound();



        return Ok(new UserVm
        {
            Id = res.Id,
            Name = res.Name,
            Age = res.Age,
            LastName = res.LastName
        });
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        _userService.Delete(id);

        return Ok();
    }

    [HttpPost]
    public ActionResult Create(int id, string name, int age, string lastName)
    {
        var userBl = new UserBl
        {
            Age = age,
            Name = name,
            LastName = lastName,
            Id = id,
        };
        _userService.Create(userBl);
        return Ok(userBl);
    }
    [HttpPost]
    public ActionResult Update(
        [FromQuery]int userId, 
        int id, 
        string name, 
        int age, 
        string lastName)
    {
        var userBl = new UserBl
        {
            Age = age,
            Name = name,
            LastName = lastName,
            Id = id,
        };
        _userService.Update(userId, userBl);
        return Ok(userBl);
    }
}