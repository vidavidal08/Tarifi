using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion
{
    public class CreateFraccionCSVCommandValidator : AbstractValidator<CreateFraccionCSVCommand>
    {

        public CreateFraccionCSVCommandValidator()
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
