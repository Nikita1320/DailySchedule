namespace DailySchedule.Contracts
{
    public class RegisterUserRequest
    {
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
    }
}
