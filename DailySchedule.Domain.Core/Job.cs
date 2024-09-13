namespace DailySchedule.Domain.Core
{
    public class Job
    {
        public int Id { get; set; }
        public string? NameTask { get; set; }
        public string? DescriptionTask { get; set; }
        public DateTime DateTask { get; set; }
        public bool IsComplete { get; set; }
    }
}
