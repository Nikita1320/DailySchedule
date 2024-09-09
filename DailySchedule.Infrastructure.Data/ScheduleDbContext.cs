using DailySchedule.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Task = DailySchedule.Domain.Core.Task;

namespace DailySchedule.Infrastructure.Data
{
    public class ScheduleDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
