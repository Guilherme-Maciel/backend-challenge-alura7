using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Repositories.Statement
{
    public interface IStatementRepository
    {
        StatementModel get(int id);
        IEnumerable<StatementModel> getHome();
        bool insert(StatementModel testimony);
        void update(StatementModel testimony);
        void delete(int id);
    }
}
