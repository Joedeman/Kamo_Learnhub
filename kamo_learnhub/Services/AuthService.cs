using kamo_learnhub.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace kamo_learnhub.Services
{
    public class AuthService
    {
        private readonly LearnHubContext _context;

        public AuthService(LearnHubContext context)
        {
            _context = context;
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _context.Users
                .Include(u => u.UserRole) // ✅ needed for role
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !user.IsActive)
                return null;

            var hashedPassword = ComputeHash(password);

            if (user.PasswordHash != hashedPassword)
                return null;

            return user;
        }

        private string ComputeHash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
