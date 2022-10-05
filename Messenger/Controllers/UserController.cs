using AutoMapper;
using Messenger.Data;
using Messenger.Dtos;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
    {
        var users = _context.Users.ToList();
        
        return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
    } 
    
    [HttpGet("{id}")]
    public ActionResult<UserReadDto> GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound("There are no users with that Id");
        }
        
        return Ok(_mapper.Map<UserReadDto>(user));
    } 
    
    [HttpGet("ByChat/{chatName}")]
    public ActionResult<IEnumerable<Chat>> GetUsersByChat(string chatName)
    {
        var chat = _context.Chats.FirstOrDefault(u => u.Name == chatName);
        if (chat == null)
        {
            return NotFound("Error: There are no chats with that Name");
        }

        var chats = _context.Users.Where(u => u.Chats.FirstOrDefault(c => c == chat) != null).ToList();

        return Ok(chats);
    } 
    
    [HttpPost]
    public ActionResult CreateUser(UserCreateDto userCreateDto)
    {
        var user = _mapper.Map<User>(userCreateDto);
        user.CreatedAt = DateTime.Now;

        _context.Add(user);
        _context.SaveChanges();
        
        return Ok(_mapper.Map<UserReadDto>(user));
    } 
    
    [HttpDelete("{id}")]
    public ActionResult<UserReadDto> DeleteUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound("There are no users with that Id");
        }
        
        _context.Remove(user);
        _context.SaveChanges();
        
        return Ok($"User[{id}] removed successfully...");
    } 
}