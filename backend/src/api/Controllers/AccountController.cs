using api.Common.Services;
using api.DTOs;
using api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class AccountController : BaseController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly TokenService _tokenService;
    public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;

    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.Username);

        if (user is null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded)
        {
            return CreateUser(user);
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto request)
    {
        if (await _userManager.Users.AnyAsync(u => u.UserName == request.Username))
        {
            ModelState.AddModelError("username", "username already exist");
            return ValidationProblem();
        }

        if (await _userManager.Users.AnyAsync(u => u.Email == request.Email))
        {
            ModelState.AddModelError("email", "email already exist");
            return ValidationProblem();
        }

        var newUser = new AppUser
        {
            UserName = request.Username,
            Email = request.Email,
            FullName = request.FullName,
            Address = request.Address
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (result.Succeeded)
        {
            return CreateUser(newUser);
        }

        return BadRequest("Problem registering user");
    }

    [HttpGet("profile/{userId:guid}")]
    public async Task<ActionResult> UserProfile(Guid userId)
    {
        await Task.CompletedTask;
        return Ok();
    }

    private UserDto CreateUser(AppUser user)
    {
        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }
}