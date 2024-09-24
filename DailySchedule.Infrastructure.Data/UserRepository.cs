using DailySchedule.Domain.Core;
using DailySchedule.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DailySchedule.Infrastructure.Data
{
    public class UserRepository:IRepository<User>
    {
        private ScheduleDbContext db;

        public UserRepository(ScheduleDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => db.Users.ToList());
        }

        public async Task<User> Get(int id)
        {
            return await Task.Run(() => db.Users.Find(id));
        }
        public Task<User> Get(Func<User, bool> condition)
        {
            throw new NotImplementedException();
        }

        public async Task Create(User users)
        {
            await Task.Run(() => db.Users.Add(users));
        }

        public async Task Update(User users)
        {
            await Task.Run(() => db.Entry(users).State = EntityState.Modified);
        }

        public async Task Delete(int id)
        {
            User user = await Task.Run(() => db.Users.Find(id));
            if (user != null)
                await Task.Run(() => db.Users.Remove(user));
        }

        public async Task<User> Get(Expression<Func<User, bool>> condition)
        {
            var user = await db.Users.AsNoTracking().FirstOrDefaultAsync(condition) ?? null;

            return user;
        }

    }
}
