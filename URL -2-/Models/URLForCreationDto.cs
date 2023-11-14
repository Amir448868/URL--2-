using System.ComponentModel.DataAnnotations;

namespace AcortURL.Models
{
    public class URLForCreationDto
    {
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Url {get; set;}

        [Required]
        public string? Categoria { get; set; }


    }
}
