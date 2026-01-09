using kamo_learnhub.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Seeder
{
    public static void SeedAdmin(LearnHubContext _db)
    {
        // -------------------------------
        // 1️⃣ Create roles if they don't exist
        // -------------------------------
        if (!_db.UserRoles.Any(r => r.RoleName == "Admin"))
        {
            _db.UserRoles.Add(new UserRole { RoleName = "Admin" });
        }
        if (!_db.UserRoles.Any(r => r.RoleName == "Student"))
        {
            _db.UserRoles.Add(new UserRole { RoleName = "Student" });
        }
        _db.SaveChanges();

        // Get the Admin role ID
        var adminRole = _db.UserRoles.First(r => r.RoleName == "Admin");

        // -------------------------------
        // 2️⃣ Create Admin user if not exists
        // -------------------------------
        if (!_db.Users.Any(u => u.Email == "marotajoseph@gmail.com"))
        {
            string password = "Test123!"; // test password
            string hashedPassword = Convert.ToBase64String(
                SHA256.HashData(Encoding.UTF8.GetBytes(password))
            );

            var adminUser = new User
            {
                Name = "Joseph",
                Surname = "Marota",
                Email = "marotajoseph@gmail.com",
                PhoneNumber = "0822267998",
                IsActive = true,
                UserRole_ID = adminRole.UserRole_ID,
                PasswordHash = hashedPassword
            };

            _db.Users.Add(adminUser);
            _db.SaveChanges();

            Console.WriteLine("Admin user created successfully!");
        }
        else
        {
            Console.WriteLine("Admin user already exists.");
        }
    }
}
