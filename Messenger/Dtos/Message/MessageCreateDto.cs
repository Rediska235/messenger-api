using System.ComponentModel.DataAnnotations;

namespace Messenger.Dtos;

public class MessageCreateDto
{
    [Required]
    public string Chat { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string Text { get; set; }
}