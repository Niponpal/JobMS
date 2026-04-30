using System.ComponentModel.DataAnnotations;

namespace JobMS.Models
{
    public class Job
    {
        [Key]
        public long Id { get; set; }

        [StringLength(12)]
        public string JobID { get; set; }

        [Required]
        [StringLength(200)]
        public string JobTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string? SalaryRange { get; set; }

        public DateTime? Deadline { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Application> Applications { get; set; } = new HashSet<Application>();

        // =========================
        // NEW FIELDS (Job Details)
        // =========================

        // Company Info
        public string? CompanyName { get; set; }
        public string? CompanyInformation { get; set; }

        // Location
        public string? JobLocation { get; set; }

        // Basic Info
        public string? Gender { get; set; }
        public string? EmploymentStatus { get; set; }

        // Salary & Benefits
        public string? CompensationAndBenefits { get; set; }

        // Skills & Responsibilities
        public string? SkillsAndExpertise { get; set; }
        public string? Responsibilities { get; set; }

        // Requirements
        public string? AdditionalRequirements { get; set; }

        // Experience & Education
        public string? Experience { get; set; }
        public string? Education { get; set; }
    }
}