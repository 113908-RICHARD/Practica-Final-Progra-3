namespace practicaFinal.Resultados
{
    public class ListadoSucursales:ResultadoBase

    {
        public List<itemSucursal> Sucursales { get; set; } = new List<itemSucursal>();
    }
    public class itemSucursal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
