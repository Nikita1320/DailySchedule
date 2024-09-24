using DailySchedule.Domain.Core;
using DailySchedule.Domain.Interfaces;
using DailySchedule.Infrastructure.Data;

namespace DailySchedule.Services.Business
{
    public class ScheduleService
    {
        private IRepository<Job> jobRepository;

        public ScheduleService(IRepository<Job> jobRepository)
        {
            this.jobRepository = jobRepository; 
        }

        public async Task<Job> Get(int id)
        {
            return await jobRepository.Get(id);
        }
        public async Task<List<Job>> GetAll()
        {
            var jobs = await jobRepository.GetAll();
            return jobs.ToList();
        }
        public async Task Create(Job job)
        {
            await jobRepository.Create(new Job());
        }
        public async Task Update(Job job)
        {
            await jobRepository.Update(job);
        }
        public async Task Delete(int id)
        {
            await jobRepository.Delete(id);
        }
    }
}
