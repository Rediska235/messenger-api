using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Messenger.Models;

public class Chat
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<User>? Users { get; set; }
    [JsonIgnore]
    public ICollection<Message>? Messages { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}