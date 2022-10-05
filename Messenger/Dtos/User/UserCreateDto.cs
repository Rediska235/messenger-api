using System.ComponentModel.DataAnnotations;

namespace Messenger.Dtos;

public class UserCreateDto
{
    [Required]
    public string Username { get; set; }
}