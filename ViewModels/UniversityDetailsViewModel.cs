using School.Models;

namespace School.Models
{
    public class UniversityDetailsViewModel
    {
        public required University University { get; set; }
        public int StudentCount { get; set; }
        public double StudentAgeAverage { get; set; }
    }
}

