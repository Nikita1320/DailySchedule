using DailySchedule.Contracts;
using DailySchedule.Services.Business;

namespace DailySchedule.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("register", Login);

            return app;

        }
        private static async Task<IResult> Register(RegisterUserRequest request, UserService userService)
        {
            await userService.Register(request.UserName, request.Password);
            return Results.Ok();
        }
        private static async Task<IResult> Login(LoginUserRequest request, UserService userService)
        {
            var token = await userService.Login(request.login, request.password);

            return Results.Ok(token);
        }
    }
}
