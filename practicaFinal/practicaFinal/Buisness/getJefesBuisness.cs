using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using practicaFinal.Data;
using practicaFinal.Resultados;
using System.Net;

namespace practicaFinal.Buisness
{
    public class getJefesBuisness
    {
        public class GetJefes : IRequest<ListadoEmpleados>
        {
            
        }

        public class EjecutaValidacion : AbstractValidator<GetJefes>
        {
            public EjecutaValidacion()
            {

            }
        }

        public class Manejador : IRequestHandler<GetJefes, ListadoEmpleados>
        {
            // propiedades
            private readonly ContextDB _contexto;

            private readonly IValidator<GetJefes> _validator;
            //constructor

            public Manejador(ContextDB contexto, IValidator<GetJefes> validator)
            {
                _contexto = contexto;
                _validator = validator;
            }

            public async Task<ListadoEmpleados> Handle(GetJefes comando, CancellationToken cancellationToken)
            {
                var result = new ListadoEmpleados();

                var validation = await _validator.ValidateAsync(comando);
                if (!validation.IsValid)
                {
                    var errors = string.Join(Environment.NewLine, validation.Errors);
                    result.SetMensajeError(errors, HttpStatusCode.InternalServerError);
                    return result;
                }

                Guid idToFind = new Guid("77bc0ec2-2f2c-11ee-be56-0242ac120002");
                var Empleados = await _contexto.Empleados.Where(c => c.IdCargo == idToFind).ToListAsync();


                if (Empleados != null)
                {
                    foreach (var item in Empleados)
                    {
                        var itemEmpleado = new ItemEmpleado();
                        itemEmpleado.Id = item.Id;
                        itemEmpleado.Nombre = item.Name;
                        

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
