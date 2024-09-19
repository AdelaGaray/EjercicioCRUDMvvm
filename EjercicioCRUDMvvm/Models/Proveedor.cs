using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioCRUDMvvm.Models
{
    [Table("Proveedores")]
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public required string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public required string Ciudad { get; set; }

        [Required]
        [StringLength(20)]
        public required string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}

