using DailySchedule.Domain.Core;
using DailySchedule.Domain.Interfaces;
using DailySchedule.Infrastructure.Data;
using DailySchedule.Infrastructure.Interfaces;
using DailySchedule.Infrastructure.Persistance;

namespace DailySchedule.Services.Business
{
    public class UserService
    {
        private IRepository<User> userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IJwtProvider JWTProvider;

        public UserService(IRepository<User> userRepository, IPasswordHasher passwordHasher, IJwtProvider JWTProvider)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.JWTProvider = JWTProvider;
        }
        public async Task Register(string login, string password)
        {
            var hashPassword = passwordHasher.Generate(password);

            var user = new User()
            {
                Id = new Guid(),
                Login = login,
                PasswordHash = hashPassword
            };
            await userRepository.Create(user);
        }
        public async Task<string> Login(string login, string password)
        {
            var user = await userRepository.Get(u => u.Login == login);

            if (user == null)
            {
                //если нет пользователя
            }

            var result = passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {

            }

            var token = JWTProvider.GenerateToken(user);

            return token;
        }
    }
}
