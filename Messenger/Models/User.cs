using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Messenger.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [JsonIgnore]
    public ICollection<Chat>? Chats { get; set; }
    [JsonIgnore]
    public ICollection<Message>? Messages { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}
