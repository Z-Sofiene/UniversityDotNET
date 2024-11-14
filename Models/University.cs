using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class University
    {
        [Key]
        public int UniversityID { get; set; }
        [Required]
        public string UniversityName { get; set; }
        [Required]
        public string UniversityAdress { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
