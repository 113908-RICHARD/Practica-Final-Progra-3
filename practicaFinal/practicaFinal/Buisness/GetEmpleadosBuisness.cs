using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using practicaFinal.Data;
using practicaFinal.Resultados;
using System.Net;

namespace practicaFinal.Buisness
{
    public class GetEmpleadosBuisness
    {
        public class GetEmpleados : IRequest<ListadoEmpleados>
        {
           
        }

        public class EjecutaValidacion : AbstractValidator<GetEmpleados>
        {
            public EjecutaValidacion()
            {
               
            }
        }

        public class Manejador : IRequestHandler<GetEmpleados, ListadoEmpleados>
        {
            // propiedades
            private readonly ContextDB _contexto;

            private readonly IValidator<GetEmpleados> _validator;
            //constructor

            public Manejador(ContextDB contexto, IValidator<GetEmpleados> validator)
            {
                _contexto = contexto;
                _validator = validator;
            }

            public async Task<ListadoEmpleados> Handle(GetEmpleados comando, CancellationToken cancellationToken)
            {
                var result = new ListadoEmpleados();

                var validation = await _validator.ValidateAsync(comando);
                if (!validation.IsValid)
                {
                    var errors = string.Join(Environment.NewLine, validation.Errors);
                    result.SetMensajeError(errors, HttpStatusCode.InternalServerError);
                    return result;
                }


                var Empleados = await _contexto.Empleados.Include(c => c.sucursal).Include(c => c.Cargo).Include(c => c.jefe).ToListAsync();
                

                if (Empleados != null)
                {
                    foreach (var item in Empleados)
                    {
                        var itemEmpleado = new ItemEmpleado();
                        itemEmpleado.Id = item.Id;
                        itemEmpleado.Nombre = item.Name;
                        itemEmpleado.Apellido = item.LastName;
                        itemEmpleado.DNI = item.DNI;
                        itemEmpleado.Cargo = item.Cargo.name;
                        itemEmpleado.Sucursal = item.sucursal.Name;
                       itemEmpleado.jefe = item.jefe.Name;
                        
                        result.ListEmpleados.Add(itemEmpleado);
                    }

                    return result;
                }

                var mensajeError = "Empleados no encontrados";
                result.SetMensajeError(mensajeError, HttpStatusCode.NotFound);
                return result;



            }
        }
    }
}
