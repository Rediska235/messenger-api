using AutoMapper;
using Messenger.Data;
using Messenger.Dtos;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Controllers;

[Route("[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ChatController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Chat>> GetAllChats()
    {
        var chats = _context.Chats.ToList();

        return Ok(chats);
    } 
    
    [HttpGet("{username}")]
    public ActionResult<IEnumerable<Chat>> GetChatsByUser(string username)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            return NotFound("Error: There are no users with that Username");
        }

        var chats = _context.Chats.Where(c => c.Users.FirstOrDefault(u => u == user) != null).ToList();
        if (chats.Count == 0)
        {
            return NotFound("That user doesn't have any chats");
        }
        
        return Ok(chats);
    } 
    
    [HttpPost]
    public ActionResult<Chat> CreateChat(ChatCreateDto chatCreateDto)
    {
        Chat chat = new(){Name = chatCreateDto.Name, CreatedAt = DateTime.Now};
        
        var users = _context.Users.Where(u => chatCreateDto.Users.Contains(u.Id)).ToList();
        chat.Users = users;
        
        _context.Add(chat);
        _context.SaveChanges();
        
        return Ok(_mapper.Map<ChatReadDto>(chat));
    }
}