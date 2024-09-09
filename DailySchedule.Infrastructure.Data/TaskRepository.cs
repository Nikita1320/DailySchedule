using Microsoft.EntityFrameworkCore;
using DailySchedule.Domain.Interfaces;
using Task = DailySchedule.Domain.Core.Task;

namespace DailySchedule.Infrastructure.Data
{
    public class TaskRepository: IRepository<Task>
    {
        private ScheduleDbContext db;

        public TaskRepository(ScheduleDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Task> GetAll ()
        {
            return db.Tasks.ToList();
        }

        public Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public void Create(Task task)
        {
            db.Tasks.Add(task);
        }

        public void Update(Task task)
        {
            db.Entry(task).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
        }
    }
}
