using WebApi.Users.Data.Models;

namespace WebApi.Users.Data.DTO_s
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string status { get; set; }
    }
}
