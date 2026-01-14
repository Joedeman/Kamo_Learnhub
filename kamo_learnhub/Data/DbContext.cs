using Microsoft.EntityFrameworkCore;

namespace kamo_learnhub.Models
{
    public class LearnHubContext : DbContext
    {
        public LearnHubContext(DbContextOptions<LearnHubContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<StudentVideo> StudentVideos { get; set; }
    }
}
