namespace DailySchedule.Infrastructure.Data
{
    public class UnitOfWork: IDisposable
    {
        private ScheduleDbContext db = new ScheduleDbContext();
        private JobRepository taskRepository;
        private UserRepository userRepository;

        public JobRepository Jobs
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new JobRepository(db);
                return taskRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
