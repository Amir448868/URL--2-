using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using URL__2_.Models.Models.Enum;

namespace AcortURL.Entities
{
    public class URL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Url { get; set; }

        public string? UrlCorta { get; set; }

        public int? Visitas { get; set; }

        public Categoria? Categorias { get; set; } = Categoria.Otros; // Propiedad de navegación para la categoría a la que pertenece

    }
}
