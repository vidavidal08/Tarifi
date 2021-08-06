using FluentValidation;

namespace NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion
{
    public  class CreateFraccionPermisoAcotacionCSVCommandValidator : AbstractValidator<CreateFraccionPermisoAcotacionCSVCommand>
    {
        public CreateFraccionPermisoAcotacionCSVCommandValidator()
        {
            RuleFor(x => x.ArchivoCSV.Length)
                    .NotNull()
                    .LessThanOrEqualTo(4 * 1024 * 1024)
                    .WithMessage("El tamaño del archivo es mayor de lo permitido");

            RuleFor(x => x.ArchivoCSV.ContentType)
                    .NotNull()
                    .Must(x => x.Equals("text/csv"))
           .WithMessage("Tipo de formato no permitido");
        }
    }
}
