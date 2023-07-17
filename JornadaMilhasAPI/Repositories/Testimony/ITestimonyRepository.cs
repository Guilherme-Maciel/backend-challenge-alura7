using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Repositories.Testimony
{
    public interface ITestimonyRepository
    {
        TestimonyModel get(int id);
        IEnumerable<TestimonyModel> getHome();
        bool insert(TestimonyModel testimony);
        void update(TestimonyModel testimony);
        void delete(int id);
    }
}
