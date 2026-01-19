using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kamo_learnhub.DTO.Student;
using kamo_learnhub.Models;

namespace kamo_learnhub.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly LearnHubContext _context;

    public StudentController(LearnHubContext context)
    {
      _context = context;
    }

    // GET: api/Student
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var students = await _context.StudentProfiles
          .Include(s => s.User)
          .Select(s => new ReadStudentDTO
          {
            Student_ID = s.Student_ID,
            Grade = s.Grade,
            Curriculum = s.Curriculum,
            IsActive = s.IsActive,
            FullName = s.User.Name + " " + s.User.Surname,
            Email = s.User.Email
          })
          .ToListAsync();

      return Ok(students);
    }

    // GET: api/Student/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var student = await _context.StudentProfiles
          .Include(s => s.User)
          .Where(s => s.Student_ID == id)
          .Select(s => new ReadStudentDTO
          {
            Student_ID = s.Student_ID,
            Grade = s.Grade,
            Curriculum = s.Curriculum,
            IsActive = s.IsActive,
            FullName = s.User.Name + " " + s.User.Surname,
            Email = s.User.Email
          })
          .FirstOrDefaultAsync();

      if (student == null)
        return NotFound();

      return Ok(student);
    }

    // POST: api/Student
    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentDTO dto)
    {
      var user = await _context.Users.FindAsync(dto.User_ID);
      if (user == null)
        return BadRequest("User does not exist.");

      var exists = await _context.StudentProfiles
          .AnyAsync(s => s.User_ID == dto.User_ID);

      if (exists)
        return BadRequest("Student already exists.");

      var student = new StudentProfile
      {
        User_ID = dto.User_ID,
        Grade = dto.Grade,
        Curriculum = dto.Curriculum,
        IsActive = dto.IsActive
      };

      _context.StudentProfiles.Add(student);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = student.Student_ID }, null);
    }

    // PUT: api/Student/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdatseStudentDTO dto)
    {
      var student = await _context.StudentProfiles.FindAsync(id);

      if (student == null)
        return NotFound();

      student.Grade = dto.Grade;
      student.Curriculum = dto.Curriculum;
      student.IsActive = dto.IsActive;

      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/Student/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
      var student = await _context.StudentProfiles.FindAsync(id);

      if (student == null)
        return NotFound();

      _context.StudentProfiles.Remove(student);
      await _context.SaveChangesAsync();

      return NoContent();
    }


    [HttpPost("register")]

    public async Task<IActionResult> RegisterStudent(RegisterStudentDTO rDTO)

    {

      using var transaction = await _context.Database.BeginTransactionAsync();

      try
      {
        var user = new User
        {

          Name = rDTO.Name,
          Surname = rDTO.Surname,
          Email = rDTO.Email,
          PasswordHash = rDTO.Password,
          PhoneNumber = rDTO.PhoneNumber,
          UserRole_ID = 2
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();



        // 2️⃣ Create Student Profile
        var student = new StudentProfile
        {
          User_ID = user.User_ID,
          Grade = rDTO.Grade,
          Curriculum = rDTO.Curriculum,
          IsActive = true
        };

        _context.StudentProfiles.Add(student);
        await _context.SaveChangesAsync();

        await transaction.CommitAsync();


        return Ok(new
        {
          user.User_ID,
          student.Student_ID
        });

      }
      catch
      {
        await transaction.RollbackAsync();
        throw;
      }
    }
  }
}
