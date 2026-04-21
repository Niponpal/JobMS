using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobMS.Auth_IdentityModel;

namespace JobMS.Models
{
    public class Application
    {
        [Key]
        public long Id { get; set; }

        // 🔥 FIX: size increase + safer naming
        [StringLength(50)]
        public string ApplicationId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal? PresentSalary { get; set; }
        public decimal? ExpectionSalary { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(200)]
        public string University { get; set; }

        // 🔥 FIX (important EF warning)
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CGPA { get; set; }

        public int? CompletionYear { get; set; }

        [StringLength(200)]
        public string ResumePath { get; set; }

        // =========================
        // FOREIGN KEYS
        // =========================

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public long JobId { get; set; }

        [ForeignKey("JobId")]
        public Job Job { get; set; }
    }
}