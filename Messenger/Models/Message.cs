using System.ComponentModel.DataAnnotations;

namespace Messenger.Models;

public class Message
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public Chat Chat { get; set; }
    [Required]
    public User Author { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}