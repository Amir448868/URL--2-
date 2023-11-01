using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int UserId { get; set; } // Propiedad de clave foránea para el usuario al que pertenece


        public int CategoriaId { get; set; } // Propiedad de clave foránea para la categoría a la que pertenece
        [InverseProperty("URLs")] // Atributo que indica que la propiedad anterior es una clave foránea
        public CategoriasURL? Categoria { get; set; }
    }
}
