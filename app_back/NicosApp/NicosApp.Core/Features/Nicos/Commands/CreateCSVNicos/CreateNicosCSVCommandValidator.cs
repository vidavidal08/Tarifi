﻿using FluentValidation;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 22-02-2021
/// </summary>
namespace NicosApp.Core.Features.Nicos.Commands.CreateCSVNicos
{
    public class CreateNicosCSVCommandValidator : AbstractValidator<CreateNicosCSVCommand>
    {
        public CreateNicosCSVCommandValidator()
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