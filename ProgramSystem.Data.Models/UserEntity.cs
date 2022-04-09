using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramSystem.Data.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
