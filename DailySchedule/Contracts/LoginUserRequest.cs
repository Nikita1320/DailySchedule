using System.ComponentModel.DataAnnotations;

namespace DailySchedule.Contracts
{
    public record LoginUserRequest(
        [Required] string login,
        [Required] string password);
}
