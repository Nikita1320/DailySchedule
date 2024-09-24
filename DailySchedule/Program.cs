using DailySchedule.Domain.Core;
using DailySchedule.Domain.Interfaces;
using DailySchedule.Extensions;
using DailySchedule.Infrastructure.Data;
using DailySchedule.Infrastructure.Interfaces;
using DailySchedule.Infrastructure.Persistance;
using DailySchedule.Services.Business;
using DailySchedule.Services.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DailySchedule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddDbContext<ScheduleDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString(nameof(ScheduleDbContext));
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Job>, JobRepository>();

            services.AddScoped<UserService>();
            services.AddScoped<ScheduleService>();

            services.AddScoped<IJwtProvider, JWTProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection(); 

            app.UseAuthentication();
            app.UseAuthorization();

            app.AddMappedEndpoints();

            app.Run();
        }
    }
}
