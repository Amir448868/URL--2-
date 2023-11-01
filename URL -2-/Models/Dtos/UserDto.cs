using AcortURL.Models.Enum;

namespace AcortURL.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
     
        public Role Role { get; set; }
    }
}
