using FluentValidation;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;

namespace WebApi.Users.Config
{
    public static class Validacija
    {
        public static void FluentValidation(IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateUserRequest>, CreateUserValidator>();
        }
    }
}
