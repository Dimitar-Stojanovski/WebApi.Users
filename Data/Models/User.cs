using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Users.Data.BaseData;

namespace WebApi.Users.Data.Models
{
    public class User:EntityBase
    {
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("phone_number")]
        public string Phone { get; set; }
        [Column("user_status")]
        public string status { get; set; }


    }

    
}
