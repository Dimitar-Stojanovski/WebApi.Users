using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Users.Data.BaseData
{
    public class EntityBase
    {
        [Required]
        [Column("id")]
        public int id { get; set; }
        [Required]
        [Column("created_at_utc")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
