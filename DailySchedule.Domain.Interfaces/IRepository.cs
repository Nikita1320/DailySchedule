using System.Threading.Tasks;

namespace DailySchedule.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task <IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(Func<T, bool> condition);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
