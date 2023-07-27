using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdCiudad { get; set; }

        [ForeignKey("IdCiudad")]
        public Ciudad Ciudad { get; set; }
    }
}
