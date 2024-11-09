using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using instakcal_backend.Application.DTOs.User;
using instakcal_backend.Application.Enums;
using instakcal_backend.Application.Interfaces;
using instakcal_backend.Application.Responses;
using instakcal_backend.Domain.Entities;
using instakcal_backend.Domain.Repositories;
namespace instakcal_backend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        private readonly IConfiguration _configuration;


        public UserService(IUserRepository userRepository,  IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;

        }

        public async Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationDto userRegistrationDtoDto)
        {
            try
            {
                if (await _userRepository.GetByEmailAsync(userRegistrationDtoDto.Email) != null)
                {
                    return new UserRegistrationResponse(code: UserRegistrationResponseStatus.USER_ALREADY_REGISTERED);
                }
                var hashedPassword = HashPassword(userRegistrationDtoDto.Password); 
                var user = new User
                {
                    Username = userRegistrationDtoDto.Username,
                    Email = userRegistrationDtoDto.Email,
                    PasswordHash = hashedPassword,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    FirstName = userRegistrationDtoDto.FirstName,
                    LastName = userRegistrationDtoDto.LastName,
                    DateOfBirth = userRegistrationDtoDto.DateOfBirth,
                    IsActive = true
                };

                await _userRepository.AddUserAsync(user);

                return new UserRegistrationResponse(code: UserRegistrationResponseStatus.USER_REGISTER_SUCCESS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new UserRegistrationResponse(UserRegistrationResponseStatus.USER_REGISTER_ERROR);
            }
        }
        
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(loginDto.UsernameOrEmail);
            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return new UserLoginResponse(UserLoginResponseStatus.USER_INVALID_CREDENTIALS, token:null);
            }

            var token = GenerateJwtToken(user.Id);

            return new UserLoginResponse(UserLoginResponseStatus.USER_LOGIN_SUCCESS, token);
        }
        
        private string GenerateJwtToken(Guid userId)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var claims = new[]
            {
                new Claim("userId", userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
        
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}