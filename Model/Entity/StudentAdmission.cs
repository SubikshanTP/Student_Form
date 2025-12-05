using System.ComponentModel.DataAnnotations;

namespace Student_Form.Model.Entity
{
    public class StudentAdmission
    {
        [Key]
        public int StudentAdmissionNumber { get; set; }

        [Required]
        [MinLength(3)]
        public string StudentName { get; set; }

        [Required]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required]
        
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Class { get; set; }
        [Required]
        public string HostelRequired { get; set; }
    }
}
