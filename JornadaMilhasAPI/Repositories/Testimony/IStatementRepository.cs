using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Repositories.Testimony
{
    public interface ITestimonyRepository
    {
        StatementModel get(int id);
        IEnumerable<StatementModel> getHome();
        bool insert(StatementModel testimony);
        void update(StatementModel testimony);
        void delete(int id);
    }
}
