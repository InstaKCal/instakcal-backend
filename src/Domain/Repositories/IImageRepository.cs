using instakcal_backend.Domain.Entities;

namespace instakcal_backend.Domain.Repositories;


public interface IImageRepository
{ 
    Task AddImageAsync(Image image);
    Task<IEnumerable<Image>> GetImagesByUserIdAsync(string userId);

}
