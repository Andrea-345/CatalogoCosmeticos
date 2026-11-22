using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatalogoCosmeticos.Models;

namespace CatalogoCosmeticos.Models 
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        
        public ICollection<Cosmetico> Cosmeticos { get; set; } = new List<Cosmetico>();
    }
}
