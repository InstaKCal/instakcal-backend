using System.Net;
using System.Net.Sockets;
using instakcal_backend.Application.Interfaces;
using instakcal_backend.Domain.Entities;
using instakcal_backend.Domain.Repositories;
using instakcal_backend.Application.DTOs.Image;

namespace instakcal_backend.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ImageService(IImageRepository imageRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _imageRepository = imageRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SaveImageAsync(SaveImageDto saveImageDto)
        {
            if (saveImageDto.OriginalImage == null || saveImageDto.ProcessedImage == null || saveImageDto.UserId == null)
                throw new ArgumentException("Both original and processed images are required.");

            var userFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", saveImageDto.UserId);
            var originalPath = Path.Combine(userFolderPath, "original");
            var processedPath = Path.Combine(userFolderPath, "processed");
            
            Directory.CreateDirectory(originalPath);
            Directory.CreateDirectory(processedPath);
            
            var originalFileName = $"{Guid.NewGuid()}_{saveImageDto.OriginalImage.FileName}";
            var originalFilePath = Path.Combine(originalPath, originalFileName);
            await using (var originalStream = new FileStream(originalFilePath, FileMode.Create))
            {
                await saveImageDto.OriginalImage.CopyToAsync(originalStream);
            }
            
            var processedFileName = $"{Guid.NewGuid()}_{saveImageDto.ProcessedImage.FileName}";
            var processedFilePath = Path.Combine(processedPath, processedFileName);
            await using (var processedStream = new FileStream(processedFilePath, FileMode.Create))
            {
                await saveImageDto.ProcessedImage.CopyToAsync(processedStream);
            }

            string originalUrl = $"/images/{saveImageDto.UserId}/original/{originalFileName}";
            string processedUrl = $"/images/{saveImageDto.UserId}/processed/{processedFileName}";

            var image = new Image
            {
                UserId = saveImageDto.UserId,
                OriginalUrl = originalUrl,
                ProcessedUrl = processedUrl,
                CreatedAt = DateTime.UtcNow
            };

            await _imageRepository.AddImageAsync(image);
        }
        
        public async Task<IEnumerable<ImageResponseDto>> GetImagesByUserIdAsync(string userId)
        {
            var images = await _imageRepository.GetImagesByUserIdAsync(userId);
            
            var request = _httpContextAccessor.HttpContext.Request;
            var port = request.Host.Port;

            var hostName = Dns.GetHostName();
            var ipAddress = Dns.GetHostAddresses(hostName)
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            var baseUrl = $"{request.Scheme}://{ipAddress}:{port}";

            return images.Select(img => new ImageResponseDto
            {
                OriginalUrl = $"{baseUrl}{img.OriginalUrl}",
                ProcessedUrl = $"{baseUrl}{img.ProcessedUrl}"
            });
        }
    }
}