using instakcal_backend.Application.DTOs.Image;
using instakcal_backend.Domain.Entities;

namespace instakcal_backend.Application.Interfaces;

public interface IImageService
{
    Task SaveImageAsync(SaveImageDto dto);

    Task<IEnumerable<ImageResponseDto>> GetImagesByUserIdAsync(string userId);
}