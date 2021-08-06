using MediatR;
using Microsoft.AspNetCore.Identity;
using NicosApp.Core.Entidades;
using NicosApp.Core.Excepciones;
using NicosApp.Core.Helpers;
using NicosApp.Core.Interfaces.Identity;
using NicosApp.Core.Interfaces.Notificacion.Email;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Seguridad.Commands.Registrar
{
    public class RegistrarCommandHandle : IRequestHandler<RegistrarUsuarioCommand, Result>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        /// <summary>
        /// 
        /// </summary>
        private readonly IEmailNotification _emailNotification;
        /// <summary>
        /// 
        /// </summary>
        private readonly ISchemaAcountUrlConfirmEmailService _schemaAcountUrlConfirmEmailService;
        public RegistrarCommandHandle(UserManager<ApplicationUser> userManager,
                                      IUsuarioRepositorio usuarioRepositorio,
                                      IEmailNotification emailNotification,
                                      ISchemaAcountUrlConfirmEmailService schemaAcountUrlConfirmEmailService
                                      )
        {
            _userManager = userManager;
            _usuarioRepositorio = usuarioRepositorio;
            _emailNotification = emailNotification;
            _schemaAcountUrlConfirmEmailService = schemaAcountUrlConfirmEmailService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            string confirmationToken = "";

            var existe = await _usuarioRepositorio.isWhereEmailAsync(request.Email);

            if (existe)
            {
                throw new ApiException("Ya éxiste un usuario registrado con ese Email");
            }

            var usuario = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Nombre = request.Nombre,
                Apellidos = request.Apellidos
            };

            var resultado = await _usuarioRepositorio.createUserAsync(usuario, request.Password);

            if (resultado.Succeeded)
            {
                //try
                //{
                //    confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                //}
                //catch (System.Exception ex)
                //{

                //    throw new ManejadorExcepcion(System.Net.HttpStatusCode.BadRequest,
                //                         ex.Message);
                //}

                //var callbackLink = _schemaAcountUrlConfirmEmailService.Geturl(usuario.Id, confirmationToken);

                ////string value = "Confirme su cuenta haciendo clic en este enlace: <a href=\"" + callbackLink + "\">link</a>";

                //var mensaje = new EmailMessage()
                //{
                //    Email = usuario.Email,
                //    Body = callbackLink,
                //    Subject = "Confirmar cuenta"

                //};

                //try
                //{
                //    await _emailNotification.Send(mensaje);
                //}
                //catch (System.Exception ex)
                //{

                //    throw new ManejadorExcepcion(System.Net.HttpStatusCode.BadRequest,
                //                           ex.Message);
                //}

                var mensaje = new EmailMessage()
                {
                    Email = request.Email,
                    Body = PlantillaEmail.crearPlantilla(request.Nombre, request.Apellidos, request.Email, request.Password),
                    Subject = "Registro completado"
                };

                try
                {
                    await _emailNotification.Send(mensaje);
                }
                catch (System.Exception ex)
                {
                    throw new ManejadorExcepcion(System.Net.HttpStatusCode.BadRequest, ex.Message);
                }
                return Result.Success("Usuario registrado correctamente");
            }
            throw new ApiException("Error en registrar la cuenta");
        }
    }
}