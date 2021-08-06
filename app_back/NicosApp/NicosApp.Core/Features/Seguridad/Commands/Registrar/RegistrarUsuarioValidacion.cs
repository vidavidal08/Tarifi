using FluentValidation;

namespace NicosApp.Core.Features.Seguridad.Commands.Registrar
{
    public class RegistrarUsuarioValidacion : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioValidacion()
        {
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("El {PropertyName} es requerido")
                     .EmailAddress().WithMessage("Se requiere un {PropertyName} válido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El {PropertyName} es requerido");

            RuleFor(x => x.Apellidos)
                  .NotEmpty()
                  .WithMessage("Los {PropertyName} son requerido");

            RuleFor(x => x.Nombre)
                   .NotEmpty()
                   .WithMessage("El {PropertyName} es requerido");
        }
    }
}
