using MediatR;

namespace practicaFinal.Resultados
{
    public class ListadoCargos:ResultadoBase
    {
        public List<itemCargo> Cargos { get; set; } = new List<itemCargo>();
    }
    public class itemCargo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
    }
}
