namespace School.Models.Repositories
{
    public interface IUniversityRepository
    {
        IList<University> GetAll();
        University GetById(int id);
        void Add(University u);
        void Edit(University u);
        void Delete(University u);
        double StudentAgeAverage(int UniversityId);

        public int StudentCount(int UniversityId);

    }
}
