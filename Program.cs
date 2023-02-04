using Microsoft.EntityFrameworkCore;
using WebApi.Users;
using WebApi.Users.Config;
using FluentValidation;
using FluentValidation.AspNetCore;
using WebApi.Users.Repositories.Generics;
using WebApi.Users.Repositories.UserRepo;
using WebApi.Users.Data.Requests;
using WebApi.Users.Middleware;
using System.Text.Json.Serialization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adding dbcontext
var _connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(_connectionString);
});

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
})
 .AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
 });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Services
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddScoped<IValidator, CreateUserValidator, CreateUserRequest>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
