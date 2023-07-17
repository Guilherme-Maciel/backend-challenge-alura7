using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Repositories.Testimony
{
    public interface ITestimonyRepository
    {
        TestimonyModel get(int id);
        IEnumerable<TestimonyModel> getHome();
        bool insert();
        bool update();
        bool delete();
    }
}
