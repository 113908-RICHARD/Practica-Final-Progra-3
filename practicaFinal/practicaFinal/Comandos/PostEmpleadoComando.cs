namespace practicaFinal.Comandos
{
    public class PostEmpleadoComando
    {
        public string Name { get; set; }
        public string Apellido { get; set; }
        public Guid IdCargo { get; set; }
        public Guid IdSucursal { get; set; }
        public string DNI { get; set; }
        public Guid IdJefe { get; set; }
    }
}
