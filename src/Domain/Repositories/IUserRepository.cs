using instakcal_backend.Domain.Entities;

namespace instakcal_backend.Domain.Repositories;


public interface IUserRepository
{ 
    Task<User> GetByEmailAsync(string email); 
    Task AddUserAsync(User user);
    
    Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail);

}
