using System.ComponentModel.DataAnnotations;

namespace instakcal_backend.Application.DTOs.User;

public class UserLoginDto
{
    [Required]
    public string UsernameOrEmail { get; set; }

    [Required]
    public string Password { get; set; }
}