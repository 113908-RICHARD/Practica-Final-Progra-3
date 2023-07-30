using MediatR;
using Microsoft.AspNetCore.Mvc;
using practicaFinal.Buisness;
using practicaFinal.Comandos;
using practicaFinal.Data;
using practicaFinal.Resultados;

namespace practicaFinal.Controllers
{
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ContextDB _contexto;
        private readonly IMediator _mediator;

        public EmpleadosController(ContextDB contexto, IMediator mediator)
        {
            _contexto = contexto;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/empleados/getEmpleados")]
        public async Task<ListadoEmpleados> GetEmpleados()
        {
            return await _mediator.Send(new GetEmpleadosBuisness.GetEmpleados
            {

            });
        }

        [HttpPost]
        [Route("api/empleados/PostNuevoEmpleado")]
        public async Task<ResutladoPostPersona> PostNuevoEmpleado([FromBody] PostEmpleadoComando comando)
        {
            return await _mediator.Send(new PostEmpleadoBuisness.PostEmpleado
            {
                Name = comando.Name,
                Apellido = comando.Apellido,
                IdCargo = comando.IdCargo,
                IdSucursal = comando.IdSucursal,
                DNI = comando.DNI,
                IdJefe = comando.IdJefe
            });
        }
        [HttpGet]
        [Route("api/cargos/obtenerCargos")]
        public async Task<ListadoCargos> obtenerCargos()
        {
            return await _mediator.Send(new GetCargosBuisness.GetCargos
            {

            });

        }
        [HttpGet]
        [Route("api/Sucursales/obtenerSucursales")]
        public async Task<ListadoSucursales> obtenerSucursales()
        {
            return await _mediator.Send(new GetSucursalesBuisness.GetSucursales
            {

            });

        }
        [HttpGet]
        [Route("api/Empleados/obtenerJefes")]
        public async Task<ListadoEmpleados> obtenerJefes()
        {
            return await _mediator.Send(new getJefesBuisness.GetJefes
            {

            });

        }
    }
}
