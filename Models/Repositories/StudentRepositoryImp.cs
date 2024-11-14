using School.Config;
using Microsoft.EntityFrameworkCore;

namespace School.Models.Repositories
{
    public class StudentRepositoryImp : IStudentRepository
    {
        readonly AppDbContext context;
        public StudentRepositoryImp(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Student> GetAll()
        {
            return context.Students.OrderBy(x => x.StudentName).Include(x => x.University).ToList();
        }
        public Student GetById(int id)
        {
            return context.Students.Where(x => x.StudentId == id).Include(x => x.University).SingleOrDefault();
        }
        public void Add(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
        }
        public void Edit(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if (s1 != null)
            {
                s1.StudentName = s.StudentName;
                s1.Age = s.Age;
                s1.BirthDate = s.BirthDate;
                s1.UniversityID = s.UniversityID;
                context.SaveChanges();
            }
        }

        public void Delete(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if (s1 != null)
            {
                context.Students.Remove(s1);
                context.SaveChanges();
            }
        }
        public IList<Student> GetStudentsByUniversityID(int? UniversityId)
        {
            return context.Students.Where(s =>
            s.UniversityID.Equals(UniversityId))
            .OrderBy(s => s.StudentName)
            .Include(std => std.UniversityID).ToList();

        }
        public IList<Student> FindByName(string name)
        {
            return context.Students.Where(s =>
            s.StudentName.Contains(name)).Include(std =>
            std.UniversityID).ToList();

        }
    }
}
