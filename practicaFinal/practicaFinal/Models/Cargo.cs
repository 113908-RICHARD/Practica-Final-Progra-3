using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal.Models
{
    [Table("Cargo")]
    public class Cargo
    {   
        public Guid id { get; set; }
        public string name { get; set; }


    }
}
