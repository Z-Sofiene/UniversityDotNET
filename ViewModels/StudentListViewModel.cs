using School.Models;

namespace School.Models
{
    public class StudentListViewModel
    {
        public IEnumerable<Student> Students { get; set; } // List of students
        public int? UniversityID { get; set; } // For search form
    }

}
