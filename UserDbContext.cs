using Microsoft.EntityFrameworkCore;
using WebApi.Users.Data.Models;

namespace WebApi.Users
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    id = 1,
                    CreatedAt = DateTime.Now,
                    UserName = "JohnDoe123",
                    FirstName = "John",
                    LastName = "Doe",
                    Password = "Password123",
                    Phone = "+123 456 789",
                    status = "user"

                },
                new UserModel
                {
                    id = 2,
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UserName = "User1234",
                    FirstName = "Test",
                    LastName = "Testson",
                    Password = "223456",
                    Phone = "+123 456 ",
                    status = "user"
                });
        }
    }
}
