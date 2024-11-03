using Microsoft.AspNetCore.Mvc;
using instakcal_backend.Application.DTOs.User;
using instakcal_backend.Application.Enums;
using instakcal_backend.Application.Interfaces;
using instakcal_backend.Application.Responses;
using Microsoft.AspNetCore.Authorization;

namespace instakcal_backend.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{

    private readonly ILogger<ImagesController> _logger;
    private readonly IUserService _userService;


    public ImagesController( ILogger<ImagesController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;

    }
    
    [Authorize]
    [HttpPost("create_image")]
    public async Task<IActionResult> CreateImage()
    {
        return Ok();
    }
    
    [Authorize]
    [HttpGet("get_images")]
    public async Task<IActionResult> GetImages()
    {
        return Ok();
    }
    
    [Authorize]
    [HttpDelete("delete_image")]
    public async Task<IActionResult> DeleteImages()
    {
        return Ok();
    }
    

}

