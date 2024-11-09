using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using instakcal_backend.Domain.Entities;
using instakcal_backend.Domain.Repositories;

namespace instakcal_backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }
    }
}