﻿using AudioApp.Logic.Contracts;
using AudioApp.Logic.Models;
using AudioApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        return Ok(_userService.GetList().Select( _ => new UserVm
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
}