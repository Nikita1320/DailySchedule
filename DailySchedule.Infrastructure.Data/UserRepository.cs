using DailySchedule.Domain.Core;
using DailySchedule.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DailySchedule.Infrastructure.Data
{
    public class UserRepository:IRepository<User>
    {
        private ScheduleDbContext db;

        public UserRepository(ScheduleDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User users)
        {
            db.Users.Add(users);
        }

        public void Update(User users)
        {
            db.Entry(users).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
