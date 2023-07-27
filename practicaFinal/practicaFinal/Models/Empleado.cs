using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
       
        public Guid IdCargo { get; set; }
        
        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }

        public Guid IdSucursal { get; set; }

        [ForeignKey("IdSucursal")]
        public Sucursal sucursal { get; set; }

        public string DNI { get; set; }
        public DateTime FechaAlta { get; set; }
        
        public Guid IdJefe { get; set; }
        [ForeignKey("IdJefe")]
        public Empleado jefe { get; set; }




    }
}
