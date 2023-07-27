using FluentValidation;
using MediatR;
using practicaFinal.Data;
using practicaFinal.Models;
using practicaFinal.Resultados;
using System.Net;

namespace practicaFinal.Buisness
   
{
    public class PostEmpleadoBuisness:IRequest<ResutladoPostPersona>
    {
        public class PostEmpleado : IRequest<ResutladoPostPersona>
        {
            public string Name { get; set; }
            public string Apellido { get; set; }
            public Guid IdCargo { get; set; }
            public Guid IdSucursal { get; set; }
            public string DNI { get; set; }
            public Guid IdJefe { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<PostEmpleado>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.IdCargo).NotEmpty();
                RuleFor(x => x.IdSucursal).NotEmpty();
                RuleFor(x => x.DNI).NotEmpty();
                RuleFor(x => x.IdJefe).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<PostEmpleado, ResutladoPostPersona>
        {
            // propiedades
            private readonly ContextDB _contexto;

            private readonly IValidator<PostEmpleado> _validator;
            //constructor

            public Manejador(ContextDB contexto, IValidator<PostEmpleado> validator)
            {
                _contexto = contexto;
                _validator = validator;
            }

            public async Task<ResutladoPostPersona> Handle(PostEmpleado comando, CancellationToken cancellationToken)
            {
                var result = new ResutladoPostPersona();

                var validation = await _validator.ValidateAsync(comando);
                if (!validation.IsValid)
                {
                    var errors = string.Join(Environment.NewLine, validation.Errors);
                    result.SetMensajeError(errors, HttpStatusCode.InternalServerError);
                    return result;
                }
                var empleado = new Empleado
                {
                    Id = Guid.NewGuid(),
                    Name = comando.Name,
                    LastName = comando.Apellido,
                    IdCargo = comando.IdCargo,
                    IdSucursal = comando.IdSucursal,
                    DNI = comando.DNI,
                    FechaAlta = DateTime.UtcNow,
                    IdJefe = comando.IdJefe

                };

         


                try
                {
                    await _contexto.Empleados.AddAsync(empleado);
                    await _contexto.SaveChangesAsync();

                    // If the code reaches this point, it means the empleado was saved successfully.
                    result.Saved = true;
                    

                    return result;
                }
                catch (Exception ex)
                {
                    // If an exception occurs during SaveChangesAsync(), it means there was an issue saving the empleado.
                    var mensajeError = "Empleado no pudo ser creado: " + ex.Message;
                    result.SetMensajeError(mensajeError, HttpStatusCode.InternalServerError);
                    result.Saved = false;

                    return result;
                }




               
               

               
            }
           
        }
    }
}
