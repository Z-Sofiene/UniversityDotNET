using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public int UniversityID { get; set; }
        public University University { get; set; }

    }
}
