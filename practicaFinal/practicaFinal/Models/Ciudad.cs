using System.ComponentModel.DataAnnotations.Schema;

namespace practicaFinal.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
