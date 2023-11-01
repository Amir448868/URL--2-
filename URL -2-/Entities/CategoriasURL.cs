using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcortURL.Entities
{
    public class CategoriasURL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? NombreCategoria { get; set; }
        [InverseProperty("Categoria")]
        public List<URL> URLs { get; set; }
    }
}
