namespace practicaFinal.Resultados
{
    public class ListadoEmpleados:ResultadoBase
    {
        public List<ItemEmpleado> ListEmpleados { get; set; } = new List<ItemEmpleado>();
    }

    public class ItemEmpleado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Sucursal { get; set; }    
        public string DNI { get; set; }
        public DateTime FechaAlta { get; set; }
        public string jefe { get; set; }
    }
}
