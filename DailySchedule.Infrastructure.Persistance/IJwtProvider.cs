using DailySchedule.Domain.Core;

namespace DailySchedule.Infrastructure.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
