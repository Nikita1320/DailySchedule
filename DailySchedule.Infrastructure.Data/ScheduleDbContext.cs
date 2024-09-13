using DailySchedule.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Job = DailySchedule.Domain.Core.Job;

namespace DailySchedule.Infrastructure.Data
{
    public class ScheduleDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
