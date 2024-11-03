using Microsoft.AspNetCore.Mvc;
using instakcal_backend.Application.DTOs.User;
using instakcal_backend.Application.Enums;
using instakcal_backend.Application.Interfaces;
using instakcal_backend.Application.Responses;

namespace instakcal_backend.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;


    public UserController( ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;

    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDtoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.RegisterUserAsync(userRegistrationDtoDto);

        if (result.Code != UserRegistrationResponseStatus.USER_REGISTER_SUCCESS) return BadRequest(result);
        _logger.LogInformation("User registered at {DT}", DateTime.UtcNow.ToLongTimeString());
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async  Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(new UserLoginResponse(code:UserLoginResponseStatus.USER_INVALID_CREDENTIALS, token:null));
        }
        
        var result = await _userService.LoginUserAsync(loginDto);

        

        if (result.Code == UserLoginResponseStatus.USER_LOGIN_SUCCESS)
        {
            _logger.LogInformation("User logged in at  {DT}", 
                DateTime.UtcNow.ToLongTimeString());
            return Ok(result);
        }
        return  BadRequest(result);

    }
}

