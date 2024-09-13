using DailySchedule.Domain.Core;
using DailySchedule.Infrastructure.Data;
using DailySchedule.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace DailySchedule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: ControllerBase
    {
        private ScheduleService scheduleService;
        public TaskController(ScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<Job>> Get()
        {
            var jobs = scheduleService.GetAll();
            if (jobs == null)
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Job>> Get(int id) 
        { 
            var job = scheduleService.Get(id);
            if(job == null)
            {
                return BadRequest();
            }
            return Ok(job);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]Job job)
        {
            if (job == null)
            {
                return BadRequest();
            }

            await scheduleService.Create(job);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put([FromBody]Job job)
        {
            if (job == null)
            {
                return BadRequest();
            }

            if (scheduleService.Get(job.Id) != null)
            {
                return BadRequest();
            }

            await scheduleService.Update(job);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (scheduleService.Get(id) != null)
            {
                return BadRequest();
            }

            await scheduleService.Delete(id);
            return Ok();
        }
    }
}
