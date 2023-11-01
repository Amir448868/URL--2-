using System.ComponentModel.DataAnnotations;

namespace AcortURL.Models
{
    public class CreateAndUpdateUserDto
    {
        
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
