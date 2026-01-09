using System.ComponentModel.DataAnnotations;

namespace kamo_learnhub.Models
{
    public class Video
    {
        [Key]
        public int Video_ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public string Thumbnail { get; set; }

        public string Subject { get; set; }

        public bool IsGeneral { get; set; }

        // Navigation
        public ICollection<StudentVideo> StudentVideos { get; set; }
    }
}
