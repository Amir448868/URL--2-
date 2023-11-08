using System.ComponentModel.DataAnnotations;
using URL__2_.Models.Models.Enum;

namespace AcortURL.Models.Dtos
{
    public class URLForCreationDto
    {
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Url { get; set; }

    

        [Required]
        public Categoria? Categorias { get; set; }


    }
}
