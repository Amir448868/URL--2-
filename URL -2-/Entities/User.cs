using AcortURL.Models.Enum;
using System.Data;

namespace AcortURL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; } = Role.User;

        

    }
}
