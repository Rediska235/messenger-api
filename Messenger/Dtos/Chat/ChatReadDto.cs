using Messenger.Models;

namespace Messenger.Dtos;

public class ChatReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public DateTime CreatedAt { get; set; }
}