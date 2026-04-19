using System.ComponentModel.DataAnnotations;
using JobMS.Auth_IdentityModel;

namespace JobMS.Models
{
    public class Application
    {
        [Key]
        public long Id { get; set; }

        [StringLength(12)]
        public string ApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal? PresentSalary { get; set; }
        public decimal? ExpectionSalary { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(200)]
        public string University { get; set; }

        public decimal? CGPA { get; set; }
        public int? CompletionYear { get; set; }

        [StringLength(200)]
        public string ResumePath { get; set; }

        // ✅ FIXED FK TYPE
        public long UserId { get; set; }

        // Navigation
        public User User { get; set; }

        public long JobId { get; set; }
        public Job Job { get; set; }
    }
}