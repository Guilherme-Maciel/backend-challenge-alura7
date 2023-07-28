using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Repositories.Destination
{
    public interface IDestinationRepository
    {
        IEnumerable<DestinationModel> GetAll();
        int DeleteById(int id);
        int UpdateById(DestinationModel destination);
        int Insert(DestinationModel destination);
    }
}
