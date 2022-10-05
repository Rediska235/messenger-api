using AutoMapper;
using Messenger.Data;
using Messenger.Dtos;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Controllers;

[Route("[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MessageController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // выводит "author": null, хотя в таблице авторы есть и если выводить только их - все норм
    [HttpGet("{chatName}")]
    public ActionResult<IEnumerable<MessageReadDto>> GetMessagesByChat(string chatName)
    {
        var chat = _context.Chats.FirstOrDefault(c => c.Name == chatName);
        if (chat == null)
        {
            return NotFound("Error: There are no chats with that Name");
        }
        
        var messages = _context.Messages.Include(m => m.Author).Where(m => m.Chat == chat).ToList();

        return Ok(_mapper.Map<IEnumerable<MessageReadDto>>(messages));
    } 
    
    [HttpPost]
    public ActionResult<Message> CreateMessage(MessageCreateDto messageCreateDto)
    {
        var chat = _context.Chats.FirstOrDefault(c => c.Name == messageCreateDto.Chat);
        if (chat == null)
        {
            return NotFound("Error: There are no chats with that Name");
        }
        var author = _context.Users.FirstOrDefault(u => u.Username == messageCreateDto.Author);
        if (author == null)
        {
            return NotFound("Error: There are no users with that Username");
        }

        Message message = new()
        {
            Chat = chat, 
            Author = author, 
            Text = messageCreateDto.Text,
            CreatedAt = DateTime.Now
        };

        _context.Add(message);
        _context.SaveChanges();
        
        return Ok(message);
    } 
}