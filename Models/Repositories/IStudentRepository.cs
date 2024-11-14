namespace School.Models.Repositories
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Edit(Student s);
        void Delete(Student s);
        IList<Student> GetStudentsByUniversityID(int? UniversityId);
        IList<Student> FindByName(string name);
    }
}