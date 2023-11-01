using System.ComponentModel.DataAnnotations;

namespace AcortURL.Models.Dtos
{
    public class URLForCreationDto
    {
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Url { get; set; }

        [Required]
        public string? Categoria { get; set; }


    }
}
