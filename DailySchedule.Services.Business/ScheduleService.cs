using DailySchedule.Domain.Core;
using DailySchedule.Infrastructure.Data;

namespace DailySchedule.Services.Business
{
    public class ScheduleService
    {
        private UnitOfWork unitOfWork;

        public ScheduleService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork; 
        }

        public async Task<Job> Get(int id)
        {
            return await unitOfWork.Jobs.Get(id);
        }
        public async Task<List<Job>> GetAll()
        {
            var jobs = await unitOfWork.Jobs.GetAll();
            return jobs.ToList();
        }
        public async Task Create(Job job)
        {
            await unitOfWork.Jobs.Create(new Job());
        }
        public async Task Update(Job job)
        {
            await unitOfWork.Jobs.Update(job);
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Jobs.Delete(id);
        }
    }
}
