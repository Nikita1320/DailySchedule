using Microsoft.EntityFrameworkCore;
using DailySchedule.Domain.Interfaces;
using DailySchedule.Domain.Core;

namespace DailySchedule.Infrastructure.Data
{
    public class JobRepository: IRepository<Job>
    {
        private ScheduleDbContext db;

        public JobRepository(ScheduleDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Job>> GetAll ()
        {
            return await Task.Run(() => db.Jobs.ToList());
        }

        public async Task<Job> Get(int id)
        {
            return await Task.Run(() => db.Jobs.Find(id));
        }

        public async Task Create(Job job)
        {
            await Task.Run(() => db.Jobs.Add(job));
        }

        public async Task Update(Job job)
        {
            await Task.Run(() => db.Entry(job).State = EntityState.Modified);
        }

        public async Task Delete(int id)
        {
            Job job = await Task.Run(() => db.Jobs.Find(id));
            if (job != null)
                await Task.Run(() => db.Jobs.Remove(job));
        }
    }
}
