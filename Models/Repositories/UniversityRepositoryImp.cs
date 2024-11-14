
using School.Config;

namespace School.Models.Repositories
{
    public class UniversityRepositoryImp : IUniversityRepository
    {
        readonly AppDbContext context;
        public UniversityRepositoryImp(AppDbContext context)
        {
            this.context = context;
        }
        public IList<University> GetAll()
        {
            return context.Universities.OrderBy(s => s.UniversityName).ToList();
        }
        public University GetById(int id)
        {
            return context.Universities.Find(id);
        }
        public void Add(University u)
        {
            context.Universities.Add(u);
            context.SaveChanges();
        }

        public void Edit(University u)
        {
            University u1 = context.Universities.Find(u.UniversityID);
            if (u1 != null)
            {
                u1.UniversityName = u.UniversityName;
                u1.UniversityAdress = u.UniversityAdress;
                context.SaveChanges();
            }
        }

        public void Delete(University university)
        {
            University u1 = context.Universities.Find(university.UniversityID);
            if (u1 != null)
            {
                context.Universities.Remove(u1);
                context.SaveChanges();
            }
        }
        public double StudentAgeAverage(int UniversityId)
        {
            if (StudentCount(UniversityId) == 0)
                return 0;
            else
                return context.Students.Where(s => s.UniversityID ==
                UniversityId).Average(e => e.Age);

        }
        public int StudentCount(int UniversityId)
        {
            return context.Students.Where(s => s.UniversityID ==
            UniversityId).Count();
        }
    }
}
