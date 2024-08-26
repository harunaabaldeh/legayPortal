using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


public class AccountController : BaseController
{
    [HttpPost("register")]
    public ActionResult Register(RegisterDto request)
    {
        var register = new RegisterDto
        {
            Username = request.Username,
            Password = request.Password
        };

        return Ok(register);
    }

    [HttpPost("login")]
    public ActionResult Login(LoginDto request)
    {
        var login = new LoginDto
        {
            Username = request.Username,
            Password = request.Password
        };

        return Ok(login);
    }

    [HttpGet("profile/{userId:guid}")]
    public async Task<ActionResult> UserProfile(Guid userId)
    {
        await Task.CompletedTask;
        return Ok();
    }
}