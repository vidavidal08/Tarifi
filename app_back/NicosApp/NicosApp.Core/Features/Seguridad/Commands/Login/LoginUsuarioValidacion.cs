using FluentValidation;

namespace NicosApp.Core.Features.Seguridad.Commands.Login
{
    public  class LoginUsuarioValidacion : AbstractValidator<LoginUsuarioCommand>
    {
        public LoginUsuarioValidacion()
        {
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("El {PropertyName} es requerido")
                     .EmailAddress().WithMessage("Se requiere un {PropertyName} válido");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El {PropertyName} es requerido");
        }
    }
}
