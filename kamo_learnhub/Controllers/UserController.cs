using kamo_learnhub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kamo_learnhub.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace kamo_learnhub.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly LearnHubContext _context;

    public UserController(LearnHubContext context)
    {
     _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
      var users = await _context.Users
        .Include(u => u.UserRole)
        .Select(u => new UserResponseDTO
        {
          User_ID = u.User_ID,
          FullName = u.Name + " " + u.Surname,
          Email = u.Email,
          Role = u.UserRole.RoleName,
          IsActive = u.IsActive
        })
        .ToListAsync();

      return Ok(users);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetUserByID(int id)
    {
      var user = await _context.Users
        .Include(u => u.UserRole)
        .Where(u => u.User_ID == id)
        .Select(u => new UpdateUserDTO

        {
          Name = u.Name,
          Surname = u.Surname,
          PhoneNumber = u.PhoneNumber,
          IsActive = u.IsActive
        })
        .FirstOrDefaultAsync();

      if (user == null)
        return NotFound();
      return Ok(user);

    }



    [HttpPost]

    public async Task<IActionResult> CreateUser(CreateUserDTO CDTO)
    {
      if (await _context.Users.AnyAsync(u => u.Email == CDTO.Email))

        return BadRequest("Email already in use.");

        var user = new User
        {
          Name = CDTO.Name,
          Surname = CDTO.Surname,
          Email = CDTO.Email,
          PhoneNumber = CDTO.PhoneNumber,
          PasswordHash = HashPassword(CDTO.Password),
          UserRole_ID = CDTO.UserRole_ID,
          IsActive = true
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAllUsers), new { id = user.User_ID }, CDTO);

      }
    private static string HashPassword(string password)
    {
      using var sha = SHA256.Create();
      var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
      return Convert.ToBase64String(bytes);
    }
  }

  }

