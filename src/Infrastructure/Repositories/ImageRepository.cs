using instakcal_backend.Domain.Entities;
using instakcal_backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace instakcal_backend.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext _context;

        public ImageRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddImageAsync(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Image>> GetImagesByUserIdAsync(string userId)
        {
            return await _context.Images
                .Where(image => image.UserId == userId) 
                .ToListAsync();
        }
    }
}