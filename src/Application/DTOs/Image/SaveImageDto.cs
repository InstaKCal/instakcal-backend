namespace instakcal_backend.Application.DTOs.Image;

public class SaveImageDto
{
    public string? UserId { get; set; }
    
    public IFormFile? OriginalImage { get; set; }
    
    public IFormFile? ProcessedImage { get; set; }
}