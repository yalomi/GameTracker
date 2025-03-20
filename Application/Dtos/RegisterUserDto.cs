using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class RegisterUserDto
{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
}