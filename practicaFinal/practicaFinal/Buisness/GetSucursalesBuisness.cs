using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using practicaFinal.Data;
using practicaFinal.Resultados;
using System.Net;

namespace practicaFinal.Buisness
{
    public class GetSucursalesBuisness
    {
        public class GetSucursales : IRequest<ListadoSucursales>
        {

        }
        public class EjecutaValidacion : AbstractValidator<GetSucursales>
        {
            public EjecutaValidacion()
            {

            }
        }
        public class Manejador : IRequestHandler<GetSucursales, ListadoSucursales>
        {
            // propiedades
            private readonly ContextDB _contexto;

            private readonly IValidator<GetSucursales> _validator;
            //constructor

            public Manejador(ContextDB contexto, IValidator<GetSucursales> validator)
            {
                _contexto = contexto;
                _validator = validator;
            }

            public async Task<ListadoSucursales> Handle(GetSucursales comando, CancellationToken cancellationToken)
            {
                var result = new ListadoSucursales();

                var validation = await _validator.ValidateAsync(comando);
                if (!validation.IsValid)
                {
                    var errors = string.Join(Environment.NewLine, validation.Errors);
                    result.SetMensajeError(errors, HttpStatusCode.InternalServerError);
                    return result;
                }


                var Sucursales = await _contexto.Sucursales.ToListAsync();


                if (Sucursales != null)
                {
                    foreach (var item in Sucursales)
                    {
                        var itemSucursal = new itemSucursal();
                        itemSucursal.Id = item.Id;
                        itemSucursal.Name = item.Name;


                        result.Sucursales.Add(itemSucursal);
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
