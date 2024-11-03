using System.ComponentModel.DataAnnotations;

namespace instakcal_backend.Application.DTOs.User;

    public class UserRegistrationDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        
        [Required]
        [MinLength(8)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string LastName { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
