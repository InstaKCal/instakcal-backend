using Microsoft.AspNetCore.Mvc;
using instakcal_backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using instakcal_backend.Application.DTOs.Image;

namespace instakcal_backend.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{

    private readonly ILogger<ImagesController> _logger;
    private readonly IImageService _imageService;


    public ImagesController( ILogger<ImagesController> logger, IImageService imageService)
    {
        _logger = logger;
        _imageService = imageService;

    }
    
    [Authorize]
    [HttpPost("create_image")]
    public async Task<IActionResult> CreateImage([FromForm] SaveImageDto saveImageDto)
    {
        await _imageService.SaveImageAsync(saveImageDto);
        return Created();
    }
    
    [Authorize]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetImagesByUserId(string userId)
    {
        try
        {
            var images = await _imageService.GetImagesByUserIdAsync(userId);
            return Ok(images);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = "An unexpected error occurred.", Details = ex.Message });
        }
    }
    [Authorize]
    [HttpDelete("delete_image")]
    public async Task<IActionResult> DeleteImages()
    {
        return Ok();
    }
    

}

