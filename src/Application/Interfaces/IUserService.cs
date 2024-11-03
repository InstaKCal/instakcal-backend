using instakcal_backend.Application.DTOs.User;
using instakcal_backend.Application.Responses;

namespace instakcal_backend.Application.Interfaces;

public interface IUserService
{
    Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationDto userRegistrationDtoDto);

    Task<UserLoginResponse> LoginUserAsync(UserLoginDto loginDto);

}