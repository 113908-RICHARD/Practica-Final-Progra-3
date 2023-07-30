using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using practicaFinal.Data;
using practicaFinal.Resultados;
using System.Net;
using static practicaFinal.Buisness.GetEmpleadosBuisness;

namespace practicaFinal.Buisness
{
    public class GetCargosBuisness
    {
        public class GetCargos : IRequest<ListadoCargos>
        {

        }
        public class EjecutaValidacion : AbstractValidator<GetCargos>
        {
            public EjecutaValidacion()
            {

            }
        }
        public class Manejador : IRequestHandler<GetCargos, ListadoCargos>
        {
            // propiedades
            private readonly ContextDB _contexto;

            private readonly IValidator<GetCargos> _validator;
            //constructor

            public Manejador(ContextDB contexto, IValidator<GetCargos> validator)
            {
                _contexto = contexto;
                _validator = validator;
            }

            public async Task<ListadoCargos> Handle(GetCargos comando, CancellationToken cancellationToken)
            {
                var result = new ListadoCargos();

                var validation = await _validator.ValidateAsync(comando);
                if (!validation.IsValid)
                {
                    var errors = string.Join(Environment.NewLine, validation.Errors);
                    result.SetMensajeError(errors, HttpStatusCode.InternalServerError);
                    return result;
                }


                var cargos = await _contexto.Cargos.ToListAsync();


                if (cargos != null)
                {
                    foreach (var item in cargos)
                    {
                        var itemCargo = new itemCargo();
                        itemCargo.Id = item.id;
                        itemCargo.Name = item.name;
                       

                        result.Cargos.Add(itemCargo );
                    }

                    return result;
                }

                var mensajeError = "Cargos no encontrados";
                result.SetMensajeError(mensajeError, HttpStatusCode.NotFound);
                return result;



            }
        }
    }
}
