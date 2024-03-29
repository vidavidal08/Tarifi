﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Seguridad.Commands.Registrar
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
